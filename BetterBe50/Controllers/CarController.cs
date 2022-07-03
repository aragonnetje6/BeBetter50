using Microsoft.AspNetCore.Mvc;

namespace BetterBe50.Entities.Controllers;

[ApiController]
[Route("rest/[controller]/")]
public class CarController : Controller
{
    private readonly List<Car> _cars = new(new Car[]
    {
        new("golf", DateTime.Now, null), new("polo", DateTime.Now, null),
        new("golf", DateTime.Now, null), new("golf", DateTime.Now, null)
    });

    [HttpPost]
    [Consumes("application/json")]
    public IActionResult CreateCar(Car car)
    {
        _cars.Add(car);
        return Created(new Uri($"/rest/Car/{_cars.Count - 1}", UriKind.Relative), null);
    }

    [HttpGet]
    public IEnumerable<Car> ReadAllCars()
    {
        return _cars;
    }

    [HttpGet("{id:int}")]
    public IActionResult ReadCar(int id)
    {
        if (_cars.Count <= id) return NotFound();
        return Ok(_cars[id]);
    }

    [HttpPut("{id:int}")]
    [Consumes("application/json")]
    public IActionResult UpdateCar(int id, Car car)
    {
        if (_cars.Count <= id) return NotFound();
        _cars[id] = car;
        return Ok();
    }

    [HttpDelete("{id:int}")]
    [Consumes("application/json")]
    public IActionResult DeleteCar(int id)
    {
        if (_cars.Count <= id) return NotFound();
        _cars.RemoveAt(id);
        return Ok();
    }
}