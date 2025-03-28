﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQueryHandler :
        IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IMapper mapper,
            IAsyncRepository<Category> categoryRepository)
        {            
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, 
            CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.ListAllAsync())
                .OrderBy(x => x.Name);

            return _mapper.Map<List<CategoryListVm>>(allCategories);
        }
    }
}
