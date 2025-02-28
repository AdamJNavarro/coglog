using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class SubjectsController(ISubjectService subjectService) : Controller { }
