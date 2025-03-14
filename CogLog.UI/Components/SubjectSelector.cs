using CogLog.UI.Contracts;
using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class SubjectSelector(ISubjectService subjectService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int? subjectId, int? categoryId)
    {
        var vm = new SubjectSelectorVm
        {
            SubjectSelectItems = await subjectService.GetSelectListAsync(categoryId),
        };

        if (subjectId.HasValue)
        {
            vm.SubjectId = subjectId.Value;
        }

        return View("Default", vm);
    }
}
