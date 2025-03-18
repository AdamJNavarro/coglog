using CogLog.App.Contracts.Data.Subject;
using CogLog.UI.Contracts;
using CogLog.UI.Models.Subject;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class SubjectsController(ISubjectService subjectService, ICategoryService categoryService)
    : Controller
{
    public async Task<IActionResult> Index([FromQuery] SubjectQueryParameters? parameters)
    {
        parameters ??= new SubjectQueryParameters();

        var data = await subjectService.GetPaginatedSubjectsAsync(parameters);

        var vm = new SubjectPaginationVm()
        {
            Data = data.Data,
            Pagination = data.Pagination,
            CategorySelectItems = await categoryService.GetSelectListAsync(),
        };

        return View(vm);
    }

    public async Task<IActionResult> Create([FromQuery] string? categoryId)
    {
        var vm = new SubjectCreateVm() { };

        if (!string.IsNullOrWhiteSpace(categoryId))
        {
            vm.CategoryId = Convert.ToInt32(categoryId);
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubjectCreateVm subject)
    {
        await subjectService.CreateSubjectAsync(subject);
        return RedirectToAction(nameof(Index));
    }

    [Route("subjects/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var data = await subjectService.GetSubjectDetailsAsync(id);
        return View(data);
    }

    [Route("subjects/{id:int}/edit", Name = "EditSubject")]
    public async Task<IActionResult> Edit(int id)
    {
        var subject = await subjectService.GetSubjectDetailsAsync(id);

        var vm = new SubjectEditVm()
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
        };
        return View(vm);
    }

    [HttpPost]
    [Route("subjects/{id:int}/edit", Name = "EditSubject")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SubjectEditVm subject)
    {
        if (id != subject.Id)
        {
            return NotFound();
        }

        var resp = await subjectService.UpdateSubjectAsync(subject);

        if (resp.Success)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(subject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await subjectService.DeleteSubjectAsync(id);

        if (response.Success)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Edit));
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectsByCategory(int categoryId)
    {
        var data = await subjectService.GetSelectListAsync(categoryId);
        return Json(data);
    }
}
