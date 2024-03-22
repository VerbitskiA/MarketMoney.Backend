using MarketMoney.Domain.Analysis.Queries;
using MarketMoney.Domain.Cabinets.Commands;
using MarketMoney.Domain.Cabinets.Queries;
using MarketMoney.MVC.Models.Cabinet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EditCabinetDto = MarketMoney.Domain.Cabinets.Queries.EditCabinetDto;

namespace MarketMoney.MVC.Controllers;

[Authorize]
public class CabinetController : Controller
{
    private readonly IMediator _mediator;
    private readonly UserManager<IdentityUser> _userManager;

    public CabinetController(IMediator mediator, UserManager<IdentityUser> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(HttpContext.User);

        var cabs = await _mediator.Send(new GetCabinetsForUserQuery(Guid.Parse(userId)));

        return View(cabs);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Analysis()
    {
        var userId = _userManager.GetUserId(HttpContext.User);

        var stats = await _mediator.Send(new GetOverallStatsQuery(Guid.Parse(userId)));
        
        return View(stats);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCabinetDto createCabinetDto)
    {
        var userId = _userManager.GetUserId(HttpContext.User);

        await _mediator.Send(new CreateCabinetCommand(Guid.Parse(userId), createCabinetDto.Title,
            createCabinetDto.ApiKey));

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var cab = await _mediator.Send(new GetCabinetForEditQuery(id));
        
        return View(cab);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(EditCabinetDto cabinet)
    {
        await _mediator.Send(new EditCabinetCommand(cabinet.Id, cabinet.Title, cabinet.ApiKey));
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var cab = await _mediator.Send(new GetCabinetDetailsQuery(id));
        
        return View(cab);
    }
}