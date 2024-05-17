using DemoAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    public ApiController(DataContext dataContext)
    {
        DataContext = dataContext;
    }

    public readonly DataContext DataContext;
}