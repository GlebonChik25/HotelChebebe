﻿using Hotel.Data.Models;
using Hotel.Data;
using Hotel.Data.Models.Users.Guests;
using Hotel.API.GraphQL.Types.Query.Data;
using Hotel.API.GraphQL.Types.Models.Input.Client;
using Hotel.API.GraphQL.Queries.Data.Common;

namespace Hotel.API.GraphQL.Queries.Data
{
    [ExtendObjectType<QueryData>]
    public class BookingQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<BookingEntity>> GetBookings([Service] IRepositoryAsync<BookingEntity> repository)
        {
            return await repository.GetAll();
        }
        public async Task<bool> AddBookings([Service] IRepositoryAsync<BookingEntity> repository, BookingEntity item)
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
    }
}
