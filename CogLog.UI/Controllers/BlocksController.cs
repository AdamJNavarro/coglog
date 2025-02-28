using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class BlocksController(IBlockService blockService) : Controller { }
