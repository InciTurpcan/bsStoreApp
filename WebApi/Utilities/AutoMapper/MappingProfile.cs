﻿using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
           
        }
    }
}
