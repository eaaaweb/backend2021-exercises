using System;
using System.Collections.Generic;
using System.Linq;
using Lesson05.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson05.Controllers
{
    public class Exercise01Controller : Controller
    {
        private CountryRepository countryRepository;
        private List<SelectListItem> countriesDropdown = new List<SelectListItem>();

        public Exercise01Controller(CountryRepository repo)
        {
            countryRepository = repo;
        }

        public IActionResult Index(string country) {
            ViewData["Title"] = "Countries";

            ViewBag.CountryCode = country;

            foreach (Country item in countryRepository.CountriesSorted)
            {
                // create a selectListItem for the dropdown list
                SelectListItem selectListItem = new SelectListItem { Text = item.Name, Value = item.CountryCode };

                // if there is a country parameter in the URL
                // the the eleent in the countries List has the same country code value as the country parameter
                if (!String.IsNullOrEmpty(country) && item.CountryCode == country)
                {
                    selectListItem.Selected = true;
                }
                
                // add the element to the dropdown list 
                countriesDropdown.Add(selectListItem);
            }


            //countriesDropdown.OrderBy(x => x.Text);
            ViewBag.Countries = countriesDropdown.OrderBy(x => x.Text);

            return View();
        }


        [HttpPost]
        public IActionResult Index(Country newCountry)
        {
            countryRepository.AddCountry(newCountry);

            
            foreach (Country item in countryRepository.CountriesSorted)
            {

                // create a selectListItem for the dropdown list
                SelectListItem selectListItem = new SelectListItem { Text = item.Name, Value = item.CountryCode };

                if (item.CountryCode == newCountry.CountryCode)
                {
                    selectListItem.Selected = true;
                }
                countriesDropdown.Add(selectListItem);
            }

           ViewBag.Countries = countriesDropdown;
           return View(newCountry);
        }
    }
}