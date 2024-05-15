using Microsoft.AspNetCore.Mvc;
using DemoJWT.Data;

namespace DemoJWT.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    public ApiController(DataContext dataContext)
    {
        DataContext = dataContext;
    }

    public readonly DataContext DataContext;
}