﻿using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using System.ComponentModel;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.API.GraphQL.Queries.Data
{
    public partial class QueryData
    {
        /*
        [UseFiltering]
        [UseSorting]
        public async Task<List<TEntity>> Get([Service] IRepositoryAsync<TEntity> repository)
        {
            return await repository.GetAll();
        }
        
        public async Task<bool> Add(TEntity item)
        {
            try
            {
                await repository.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        */
    }
}