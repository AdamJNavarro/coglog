using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vonavulary.App.Constants;
using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.Domain;
using Vonavulary.UI.Contracts;
using Vonavulary.UI.Models;
using Vonavulary.UI.Models.Word;

namespace Vonavulary.UI.Controllers;

public class WordsController(IWordService wordService) : Controller
{
    [ViewData]
    public string Title { get; set; }

    public async Task<IActionResult> Index([FromQuery] WordsQueryParameters? parameters)
    {
        Title = "Words";
        parameters ??= new WordsQueryParameters();

        var data = await wordService.GetWordsAsync(parameters);

        var vm = new WordPaginationVm() { Data = data.Data, Pagination = data.Pagination };

        return View(vm);
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    public IActionResult Create()
    {
        Title = "New Word";

        PrepareLanguageDropdown();
        PreparePartOfSpeechDropdown();

        return View();
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WordCreateVm word)
    {
        await wordService.CreateWordAsync(word);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [Route("words/{id:int}/edit", Name = "EditWord")]
    public async Task<IActionResult> Edit(int id)
    {
        var word = await wordService.GetWordDetailsAsync(id);

        Title = "Edit Word";

        var vm = new WordEditVm()
        {
            Id = word.Id,
            LearnedAt = word.LearnedAt,
            Spelling = word.Spelling,
            Definition = word.Definition,
            ExtraInfo = word.ExtraInfo,
            Language = word.Language,
            PartOfSpeech = word.PartOfSpeech,
        };
        PrepareLanguageDropdown(word.Language);
        PreparePartOfSpeechDropdown(word.PartOfSpeech);

        return View(vm);
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [HttpPost]
    [Route("words/{id:int}/edit", Name = "EditWord")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, WordEditVm word)
    {
        if (id != word.Id)
        {
            return NotFound();
        }

        var resp = await wordService.UpdateWordAsync(word);

        return resp.Success ? RedirectToAction(nameof(Index)) : View(word);
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await wordService.DeleteWordAsync(id);

        return RedirectToAction(response.Success ? nameof(Index) : nameof(Edit));
    }

    private void PrepareLanguageDropdown(Language selectedLanguage = Language.English)
    {
        var items = Enum.GetValues(typeof(Language))
            .Cast<Language>()
            .Select(l => new SelectListItem
            {
                Value = ((int)l).ToString(), // Convert enum to int
                Text = l.ToString(),
                Selected = l == selectedLanguage,
            })
            .ToList();

        ViewBag.LanguageOptions = items;
    }

    private void PreparePartOfSpeechDropdown(PartOfSpeech selectedPart = PartOfSpeech.Noun)
    {
        var items = Enum.GetValues(typeof(PartOfSpeech))
            .Cast<PartOfSpeech>()
            .Select(l => new SelectListItem
            {
                Value = ((int)l).ToString(), // Convert enum to int
                Text = l.ToString(),
                Selected = l == selectedPart,
            })
            .ToList();

        ViewBag.PartOfSpeechOptions = items;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // queries
        // calculations
        var model = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        };
        return View(model);
    }
}
