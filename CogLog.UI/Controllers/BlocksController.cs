using CogLog.UI.Contracts;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class BlocksController(
    IBlockService blockService,
    ICategoryService categoryService,
    ISubjectService subjectService,
    ITopicService topicService
) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await blockService.GetBlocksAsync();
        var sortedData = data.OrderByDescending(x => x.DateAdded).ToList();
        return View(sortedData);
    }

    // CREATE - GET
    public async Task<IActionResult> Create()
    {
        var categories = await categoryService.GetCategoriesAsync();
        var vm = new CreateBlockVm
        {
            Categories = categories
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Label })
                .ToList(),
        };

        return View(vm);
    }

    // CREATE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBlockVm vm)
    {
        await blockService.CreateBlockAsync(vm);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectsByCategory(int categoryId)
    {
        var data = await subjectService.GetSubjectsByCategoryAsync(categoryId);
        var subjects = data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Label,
            })
            .ToList();

        return Json(subjects);
    }

    [HttpGet]
    public async Task<IActionResult> GetTopicsBySubject(int subjectId)
    {
        var data = await topicService.GetTopicsBySubjectAsync(subjectId);
        var topics = data.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Label,
        });
        return Json(topics);
    }
}

//
// // Controllers/PostsController.cs
// public class PostsController : Controller
// {
//     private readonly ApplicationDbContext _context;
//
//     public PostsController(ApplicationDbContext context)
//     {
//         _context = context;
//     }
//
//     // GET: Posts/GetAuthorsByCategory
//     [HttpGet]
//     public IActionResult GetAuthorsByCategory(int categoryId)
//     {
//         var authors = _context.Authors
//             .Where(a => a.CategoryId == categoryId)
//             .Select(a => new SelectListItem
//             {
//                 Value = a.Id.ToString(),
//                 Text = a.Name
//             })
//             .ToList();
//
//         return Json(authors);
//     }
//
//     // GET: Posts/GetTagsByAuthor
//     [HttpGet]
//     public IActionResult GetTagsByAuthor(int authorId)
//     {
//         var tags = _context.Tags
//             .Where(t => t.AuthorId == authorId)
//             .Select(t => new SelectListItem
//             {
//                 Value = t.Id.ToString(),
//                 Text = t.Name
//             })
//             .ToList();
//
//         return Json(tags);
//     }
//
//     // GET: Posts/Create
//     public IActionResult Create()
//     {
//         var viewModel = new CreatePostViewModel
//         {
//             AvailableCategories = _context.Categories
//                 .Select(c => new SelectListItem
//                 {
//                     Value = c.Id.ToString(),
//                     Text = c.Name
//                 })
//
//             // We'll load authors and tags via AJAX when categories/authors are selected
//         };
//
//         return View(viewModel);
//     }
//
//     // POST: Posts/Create
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> Create(CreatePostViewModel viewModel)
//     {
//         if (ModelState.IsValid)
//         {
//             // Create new post
//             var post = new Post
//             {
//                 Title = viewModel.Title,
//                 Content = viewModel.Content,
//                 CategoryId = viewModel.CategoryId,
//                 AuthorId = viewModel.AuthorId
//             };
//
//             // Handle the many-to-many relationship with Tags
//             if (viewModel.SelectedTagIds != null && viewModel.SelectedTagIds.Any())
//             {
//                 // Fetch the selected tags from the database
//                 var selectedTags = await _context.Tags
//                     .Where(t => viewModel.SelectedTagIds.Contains(t.Id))
//                     .ToListAsync();
//
//                 // Add the tags to the post
//                 foreach (var tag in selectedTags)
//                 {
//                     post.Tags.Add(tag);
//                 }
//             }
//
//             _context.Add(post);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//         // If we got this far, something failed, redisplay form
//         viewModel.AvailableCategories = _context.Categories
//             .Select(c => new SelectListItem
//             {
//                 Value = c.Id.ToString(),
//                 Text = c.Name
//             });
//
//         if (viewModel.CategoryId.HasValue)
//         {
//             viewModel.AvailableAuthors = _context.Authors
//                 .Where(a => a.CategoryId == viewModel.CategoryId.Value)
//                 .Select(a => new SelectListItem
//                 {
//                     Value = a.Id.ToString(),
//                     Text = a.Name
//                 });
//         }
//
//         if (viewModel.AuthorId.HasValue)
//         {
//             viewModel.AvailableTags = _context.Tags
//                 .Where(t => t.AuthorId == viewModel.AuthorId.Value)
//                 .Select(t => new SelectListItem
//                 {
//                     Value = t.Id.ToString(),
//                     Text = t.Name
//                 });
//         }
//
//         return View(viewModel);
//     }
//
//     // GET: Posts/Edit/5
//     public async Task<IActionResult> Edit(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var post = await _context.Posts
//             .Include(p => p.Tags)
//             .FirstOrDefaultAsync(p => p.Id == id);
//
//         if (post == null)
//         {
//             return NotFound();
//         }
//
//         var viewModel = new EditPostViewModel
//         {
//             Id = post.Id,
//             Title = post.Title,
//             Content = post.Content,
//             CategoryId = post.CategoryId,
//             AuthorId = post.AuthorId,
//             SelectedTagIds = post.Tags.Select(t => t.Id).ToList(),
//
//             AvailableCategories = _context.Categories
//                 .Select(c => new SelectListItem
//                 {
//                     Value = c.Id.ToString(),
//                     Text = c.Name
//                 })
//         };
//
//         // If a category is selected, load the authors for that category
//         if (post.CategoryId.HasValue)
//         {
//             viewModel.AvailableAuthors = _context.Authors
//                 .Where(a => a.CategoryId == post.CategoryId.Value)
//                 .Select(a => new SelectListItem
//                 {
//                     Value = a.Id.ToString(),
//                     Text = a.Name
//                 });
//         }
//
//         // If an author is selected, load the tags for that author
//         if (post.AuthorId.HasValue)
//         {
//             viewModel.AvailableTags = _context.Tags
//                 .Where(t => t.AuthorId == post.AuthorId.Value)
//                 .Select(t => new SelectListItem
//                 {
//                     Value = t.Id.ToString(),
//                     Text = t.Name
//                 });
//         }
//
//         return View(viewModel);
//     }
//
//     // POST: Posts/Edit/5
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> Edit(int id, EditPostViewModel viewModel)
//     {
//         if (id != viewModel.Id)
//         {
//             return NotFound();
//         }
//
//         if (ModelState.IsValid)
//         {
//             try
//             {
//                 // Get the existing post from the database
//                 var post = await _context.Posts
//                     .Include(p => p.Tags)
//                     .FirstOrDefaultAsync(p => p.Id == id);
//
//                 if (post == null)
//                 {
//                     return NotFound();
//                 }
//
//                 // Update the post properties
//                 post.Title = viewModel.Title;
//                 post.Content = viewModel.Content;
//                 post.CategoryId = viewModel.CategoryId;
//                 post.AuthorId = viewModel.AuthorId;
//
//                 // Update the tags
//                 // First, clear existing tags
//                 post.Tags.Clear();
//
//                 // Then add the selected tags
//                 if (viewModel.SelectedTagIds != null && viewModel.SelectedTagIds.Any())
//                 {
//                     var selectedTags = await _context.Tags
//                         .Where(t => viewModel.SelectedTagIds.Contains(t.Id))
//                         .ToListAsync();
//
//                     foreach (var tag in selectedTags)
//                     {
//                         post.Tags.Add(tag);
//                     }
//                 }
//
//                 _context.Update(post);
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!PostExists(viewModel.Id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return RedirectToAction(nameof(Index));
//         }
//
//         // If we got this far, something failed, redisplay form
//         viewModel.AvailableCategories = _context.Categories
//             .Select(c => new SelectListItem
//             {
//                 Value = c.Id.ToString(),
//                 Text = c.Name
//             });
//
//         if (viewModel.CategoryId.HasValue)
//         {
//             viewModel.AvailableAuthors = _context.Authors
//                 .Where(a => a.CategoryId == viewModel.CategoryId.Value)
//                 .Select(a => new SelectListItem
//                 {
//                     Value = a.Id.ToString(),
//                     Text = a.Name
//                 });
//         }
//
//         if (viewModel.AuthorId.HasValue)
//         {
//             viewModel.AvailableTags = _context.Tags
//                 .Where(t => t.AuthorId == viewModel.AuthorId.Value)
//                 .Select(t => new SelectListItem
//                 {
//                     Value = t.Id.ToString(),
//                     Text = t.Name
//                 });
//         }
//
//         return View(viewModel);
//     }
//
//     private bool PostExists(int id)
//     {
//         return _context.Posts.Any(e => e.Id == id);
//     }
// }
