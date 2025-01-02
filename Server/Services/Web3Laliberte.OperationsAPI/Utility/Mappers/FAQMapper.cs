using System.Collections.Generic;
using System.Linq;
using Web3Laliberte.OperationsAPI.Models;
using Web3Laliberte.OperationsAPI.ViewModels;

namespace Web3Laliberte.OperationsAPI.Utility.Mappers
{
    public static class FAQMapper
    {
        public static FAQViewModel ToViewModel(FAQ model)
        {
            return new FAQViewModel
            {
                Id = model.Id,
                Question = model.Question,
                Answer = model.Answer
            };
        }

        public static FAQ ToModel(FAQViewModel viewModel)
        {
            return new FAQ
            {
                Id = viewModel.Id,
                Question = viewModel.Question,
                Answer = viewModel.Answer
            };
        }

        public static IEnumerable<FAQViewModel> ToViewModelList(IEnumerable<FAQ> models)
        {
            return models.Select(ToViewModel).ToList();
        }

        public static IEnumerable<FAQ> ToModelList(IEnumerable<FAQViewModel> viewModels)
        {
            return viewModels.Select(ToModel).ToList();
        }
    }
}