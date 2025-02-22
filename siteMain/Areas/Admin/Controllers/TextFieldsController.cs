﻿using Microsoft.AspNetCore.Mvc;
using siteMain.Domain;
using siteMain.Domain.Entities;
using siteMain.Service;

namespace siteMain.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager _dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var textFieldsByCodeWord = _dataManager.TextFields.GetTextFieldsByCodeWord(codeWord);
            return View(textFieldsByCodeWord);
        }

        [HttpPost]
        public IActionResult Edit(TextFields model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.TextFields.SaveTextFields(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
