using ProjectCars.Models;
using ProjectCars.Services;
using Microsoft.AspNetCore.Mvc;


namespace ProjectCars.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CarsController : ControllerBase
{
    private readonly CarsService _carsService;

    public CarsController(CarsService carsService) => _carsService = carsService;

    [HttpGet]
    public async Task<List<Cars>> Get() => await _carsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Cars>> Get(string id)
    {
        var cars = await _carsService.GetAsync(id);

        if (cars is null)
        {
            return NotFound();
        }

        return cars;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Cars newCars)
    {
        await _carsService.CreateAsync(newCars);

        return CreatedAtAction(nameof(Get), new { id = newCars.Id }, newCars);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Cars updatedCars)
    {
        var cars = await _carsService.GetAsync(id);

        if (cars is null)
        {
            return NotFound();
        }

        updatedCars.Id = cars.Id;

        await _carsService.UpdateAsync(id, updatedCars);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var cars = await _carsService.GetAsync(id);

        if (cars is null)
        {
            return NotFound();
        }

        await _carsService.RemoveAsync(id);

        return NoContent();
    }
}
