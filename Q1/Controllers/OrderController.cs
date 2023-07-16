using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private PE_PRN_23SumContext _context;

        public OrderController(PE_PRN_23SumContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet("Index")]
        public IActionResult Get()
        {
            var x = _context.Orders.Include(y => y.Employee).ToList().Select(x => new
            {
                orderId = x.OrderId,
                employeeId = x.EmployeeId,
                employeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                orderDate = x.OrderDate,
                requiredDate = x.RequiredDate,
                shippedDate = x.ShippedDate,
                totalCost = TotalCost(x.OrderId)
            });
            return Ok(x);
        }

        private decimal TotalCost(int  orderId)
        {
            decimal sum = 0;
            var x = _context.OrderDetails.Include(x => x.Product).Where(x => x.OrderId == orderId).ToList();
            foreach (var item in x)
            {
                sum += ( (decimal)(1 - item.Discount) * item.Quantity * item.UnitPrice);
            }
            return sum;
        }

        [HttpGet("List/{minyear}/{maxyear}")]
        public IActionResult GetMinMaxYear(int minyear, int maxyear)
        {
            var x = _context.Orders.Include(y => y.Employee).Where(y => y.OrderDate.Value.Year >= minyear && y.OrderDate.Value.Year <= maxyear).ToList().Select(x => new
            {
                orderId = x.OrderId,
                employeeId = x.EmployeeId,
                employeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                orderDate = x.OrderDate,
                requiredDate = x.RequiredDate,
                shippedDate = x.ShippedDate,
                totalCost = TotalCost(x.OrderId)
            });
            return Ok(x);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            
            if(order == null)
            {
                return NotFound("The requested order could not be found");
            }
            else
            {
                var orderDetail = _context.OrderDetails.Where(x => x.OrderId == id).ToList();
                if(orderDetail.Any())
                {
                    _context.OrderDetails.RemoveRange(orderDetail);
                    _context.SaveChanges();
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Ok();
            }
           
        }
    }
}
