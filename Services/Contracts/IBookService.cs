﻿using Entities.DataTransferObject;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetOneBookByIdAsync(int id,bool trackChanges);
        Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto);
        Task UpdateOneBookAsync(int id,BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges );
    }
}
