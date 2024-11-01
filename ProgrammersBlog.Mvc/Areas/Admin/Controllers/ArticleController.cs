﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
		private readonly IToastNotification _toastNotification;


		public ArticleController(IArticleService articleService, ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, IToastNotification toastNotification) : base(userManager, mapper, imageHelper)
		{
			_articleService = articleService;
			_categoryService = categoryService;
			_toastNotification = toastNotification;
		}
        [Authorize(Roles="SuperAdmin,Article.Read")]
		[HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllByNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success) return View(result.Data);
            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin,Article.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ArticleAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }

            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin,Article.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel articleAddViewModel)
        {

            var articleAddDto = Mapper.Map<ArticleAddDto>(articleAddViewModel);
            var imageResult = await ImageHelper.Upload(articleAddViewModel.Title,
                articleAddViewModel.ThumbnailFile, PictureType.Post);
            articleAddDto.Thumbnail = imageResult.Data.FullName;
            var result = await _articleService.AddAsync(articleAddDto, LoggedInUser.UserName, LoggedInUser.Id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                _toastNotification.AddSuccessToastMessage(result.Message);
                return RedirectToAction("Index", "Article");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
            }


            var categoriesResult = await _categoryService.GetAllByNonDeletedAsync();
            if (categoriesResult.ResultStatus == ResultStatus.Success)
            {
                articleAddViewModel.Categories = categoriesResult.Data.Categories;
            }
            else
            {
                articleAddViewModel.Categories = new List<Category>();
            }

            return View(articleAddViewModel);
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpGet] //Makale guncellemek ıcın veriyi View a gondermeyi amaçlıyor.
        public async Task<IActionResult> Update(int articleId)
        {
            var articleResult = await _articleService.GetArticleUpdateDtoAsync(articleId);
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (articleResult.ResultStatus == ResultStatus.Success && categoriesResult.ResultStatus == ResultStatus.Success)
            {
                var articleUpdateViewModel = Mapper.Map<ArticleUpdateViewModel>(articleResult.Data);
                //Mapper kullanarak DTO dan ViewModel e donusum yaparak View da kullanılıcak veriyi duzenlemıs oluyosun.
                articleUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(articleUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateViewModel articleUpdateViewModel)
        {
            bool isNewThumbnailUploaded = false;
            var oldThumbnail = articleUpdateViewModel.Thumbnail;

            // Yeni bir resim yüklenip yüklenmediğini kontrol ediyoruz.
            if (articleUpdateViewModel.ThumbnailFile != null)
            {
                var uploadedImageResult = await ImageHelper.Upload(articleUpdateViewModel.Title,
                    articleUpdateViewModel.ThumbnailFile, PictureType.Post);
                articleUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                    ? uploadedImageResult.Data.FullName
                    : "postImages/defaultThumbnail.jpg";
                if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                {
                    isNewThumbnailUploaded = true;
                }
            }

            // DTO'ya Map işlemi
            var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(articleUpdateViewModel);

            // Güncelleme işlemi
            var result = await _articleService.UpdateAsync(articleUpdateDto, LoggedInUser.UserName);
            if (result.ResultStatus == ResultStatus.Success)
            {
                // Eğer yeni resim yüklendiyse eski resmi siliyoruz.
                if (isNewThumbnailUploaded)
                {
                    ImageHelper.Delete(oldThumbnail);
                }
				_toastNotification.AddSuccessToastMessage(result.Message);
				return RedirectToAction("Index", "Article");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
            }

            // Kategorileri tekrardan getirip view model'e ekliyoruz.
            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            articleUpdateViewModel.Categories = categories.Data.Categories;

            return View(articleUpdateViewModel);
        }

        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int articleId)
        {
            var result = await _articleService.DeleteAsync(articleId,LoggedInUser.UserName);
            var articleResult = JsonSerializer.Serialize(result);
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllByNonDeletedAndActiveAsync();
            var articleResult = JsonSerializer.Serialize(articles, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articleResult);
        }

    }
}
