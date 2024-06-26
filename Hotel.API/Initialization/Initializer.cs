﻿using HotChocolate.Execution.Configuration;
using Hotel.API.GraphQL.Models.Hotel;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Application.Converters;
using Hotel.Application.Services.Data;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models;
using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Common;
using Hotel.Core.Models.Users.Guests;
using Hotel.Core.Models.Users.Staff;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Hotel.API.Initialization
{
    internal static class Initializer
    {
        public static void CreateHotels() 
        {
            RoomTypeModel Economy = new RoomTypeModel(Guid.NewGuid(), "Эконом", new List<RoomModel>());
            RoomTypeModel StdOneBed = new RoomTypeModel(Guid.NewGuid(), "Стандарт с одной двухспальной кроватью", new List<RoomModel>());
            RoomTypeModel StdTwoBeds = new RoomTypeModel(Guid.NewGuid(), "Стандарт с двумя кроватями", new List<RoomModel>());
            RoomTypeModel Superior = new RoomTypeModel(Guid.NewGuid(), "Супериор с одной двухспальной кроватью", new List<RoomModel>());
            RoomTypeModel Studio = new RoomTypeModel(Guid.NewGuid(), "Студия", new List<RoomModel>());
            RoomTypeModel Apts = new RoomTypeModel(Guid.NewGuid(), "Аппартаменты", new List<RoomModel>());
            RoomTypeModel Lux = new RoomTypeModel(Guid.NewGuid(), "Люкс", new List<RoomModel>());
            RoomTypeModel President = new RoomTypeModel(Guid.NewGuid(), "Президентский люкс", new List<RoomModel>());

            RoomViewModel NoWindow = new RoomViewModel(Guid.NewGuid(), "Нет окон", new List<RoomModel>());
            RoomViewModel Blocked = new RoomViewModel(Guid.NewGuid(), "Загорожен", new List<RoomModel>());
            RoomViewModel Sightseen = new RoomViewModel(Guid.NewGuid(), "На достопримечательность", new List<RoomModel>());
            RoomViewModel Nature = new RoomViewModel(Guid.NewGuid(), "Природный", new List<RoomModel>());
            RoomViewModel Urban = new RoomViewModel(Guid.NewGuid(), "Городской", new List<RoomModel>());
            RoomViewModel Other = new RoomViewModel(Guid.NewGuid(), "Не определен", new List<RoomModel>());

            RoomModel Room1 = new RoomModel(Guid.NewGuid(), 1, 2000, 15, 0, NoWindow, Economy, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room2 = new RoomModel(Guid.NewGuid(), 2, 2300, 15, 0, Blocked, Economy, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room3 = new RoomModel(Guid.NewGuid(), 3, 3000, 20, 0, Urban, StdOneBed, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room4 = new RoomModel(Guid.NewGuid(), 4, 3000, 20, 0, Nature, StdOneBed, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room5 = new RoomModel(Guid.NewGuid(), 5, 3000, 20, 0, Urban, StdTwoBeds, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room6 = new RoomModel(Guid.NewGuid(), 6, 3000, 20, 0, Nature, StdTwoBeds, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room7 = new RoomModel(Guid.NewGuid(), 7, 4200, 25, 0, Urban, Superior, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room8 = new RoomModel(Guid.NewGuid(), 8, 4500, 25, 0, Sightseen, Superior, 2, new HotelModel(), new List<BookingModel>());
            RoomModel Room9 = new RoomModel(Guid.NewGuid(), 9, 7000, 35, 0, Sightseen, Lux, 3, new HotelModel(), new List<BookingModel>());
            RoomModel Room10 = new RoomModel(Guid.NewGuid(), 10, 7000, 35, 0, Nature, Lux, 3, new HotelModel(), new List<BookingModel>());
            RoomModel Room11 = new RoomModel(Guid.NewGuid(), 9, 7000, 35, 0, Sightseen, President, 4, new HotelModel(), new List<BookingModel>());
            
            ServiceTypeModel Meal = new ServiceTypeModel(Guid.NewGuid(), "Питание", List<ServiceModel>());
            ServiceTypeModel Spa = new ServiceTypeModel(Guid.NewGuid(), "СПА", List<ServiceModel>());
            ServiceTypeModel Transfer = new ServiceTypeModel(Guid.NewGuid(), "Трансфер", List<ServiceModel>());
            ServiceTypeModel Excursion = new ServiceTypeModel(Guid.NewGuid(), "Экскурсия", List<ServiceModel>());

            ServiceModel Breakfast = new ServiceModel(Guid.NewGuid(), "Завтрак", 400, Meal, List<HotelModel>(), List<BookingModel()>);
            ServiceModel Dinner = new ServiceModel(Guid.NewGuid(), "Ужин", 600, Meal, List<HotelModel>(), List <BookingModel()>);
            ServiceModel Massage = new ServiceModel(Guid.NewGuid(), "Массаж", 1000, Spa, List<HotelModel>(), List <BookingModel()>);
            ServiceModel Sauna = new ServiceModel(Guid.NewGuid(), "Баня", 800, Spa, List<HotelModel>(), List < BookingModel() >);
            ServiceModel FromAirport = new ServiceModel(Guid.NewGuid(), "Трансфер от аэропорта", 2000, Transfer, List<HotelModel>(), List < BookingModel() >);
            ServiceModel ToAirport = new ServiceModel(Guid.NewGuid(), "Трансфер до аэропорта", 2000, Transfer, List<HotelModel>(), List < BookingModel() >);
            ServiceModel SightseenExcursionSPb = new ServiceModel(Guid.NewGuid(), "Обзорная экскурсия по Санкт-Петербургу", 2000, Excursion, List<HotelModel>(), List < BookingModel() >);
            ServiceModel RoofsExcursionSPb = new ServiceModel(Guid.NewGuid(), "Экскурсия по крышам Санкт-Петербурга", 1500, Excursion, List<HotelModel>(), List <BookingModel()>);

            HotelModel Hotel = new HotelModel(Guid.NewGuid(), "Chebebe Bolshaya Morskaya", "г. Санкт-Петербург", 0, 4, new List<RoomModel>(), new List<ServiceModel>());

            PositionTypeModel Director = new PositionTypeModel(Guid.NewGuid(), "Директор", List<StaffModel>());
            PositionTypeModel ViceDirector = new PositionTypeModel(Guid.NewGuid(), "Заместитель Директора", List<StaffModel>());
            PositionTypeModel Receptionist = new PositionTypeModel(Guid.NewGuid(), "Администратор стойки регистрации", List<StaffModel>());
            PositionTypeModel Maid = new PositionTypeModel(Guid.NewGuid(), "Горничная", List<StaffModel>());
            PositionTypeModel LobbyBoy = new PositionTypeModel(Guid.NewGuid(), "Коридорный", List<StaffModel>());
            PositionTypeModel SeniorСoncierge = new PositionTypeModel(Guid.NewGuid(), "Старший консьерж", List<StaffModel>());
            PositionTypeModel Waiter = new PositionTypeModel(Guid.NewGuid(), "Официант", List<StaffModel>());
            PositionTypeModel Bartender = new PositionTypeModel(Guid.NewGuid(), "Бармен", List<StaffModel>());
            PositionTypeModel SecurityGuard= new PositionTypeModel(Guid.NewGuid(), "Охранник", List<StaffModel>());
        }



        private static WebApplicationBuilder? innerbBuilder;
        private static IServiceCollection? innerServices;

        public static WebApplicationBuilder Initialize(string[] args)
        {
            innerbBuilder = WebApplication.CreateSlimBuilder(args);
            innerServices = innerbBuilder.Services;
            ConfigurationManager configuration = innerbBuilder.Configuration;
            innerServices.AddControllers();
            innerServices.AddEndpointsApiExplorer();
            innerServices.AddDbContext<HotelDbContext>(
            options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(HotelDbContext)));
            });
            HotelDbContext hotelDbContext = innerServices.BuildServiceProvider().GetService<HotelDbContext>();
            CreateHotels(hotelDbContext);
            AddGraphQLConfigure(configuration);
            AddRepositories();
            AddRepositoryServices();           
            return innerbBuilder;
        }

        public static WebApplication Startup(WebApplicationBuilder builder)
        {
            WebApplication app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.MapControllers();
            app.MapGraphQL();
            app.Run();
            return app;
        }

        private static void AddGraphQLConfigure(ConfigurationManager configuration)
        {
            IRequestExecutorBuilder RequestExecutorBuilder = innerServices.AddGraphQLServer();
            RequestExecutorBuilder.AddQueryType<Test<BookingEntity,BookingModel,BookingQL>>().AddFiltering().AddProjections().AddSorting();        
        } 

        private static void AddRepositories()
        {
            HotelDbContext hotelDbContext = innerServices.BuildServiceProvider().GetService<HotelDbContext>();
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Bookings);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Guests);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Services);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.ServiceTypes);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Feedbacks);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Staff);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.PositionTypes);
        }
        private static void AddRepository<TEntity>(this IServiceCollection services, HotelDbContext hotelDbContext, DbSet<TEntity> dbSet) where TEntity : Entity
        {
            innerServices.AddScoped<IRepositoryAsync<TEntity>, Repository<TEntity>>(resolver =>
            {
                return new Repository<TEntity>(hotelDbContext, dbSet);
            });
        }

        private static void AddRepositoryServices()
        {
            innerServices.AddScoped<IRepositoryServicesCollection, RepositoryServicesCollection>();
            IRepositoryServicesCollection collection = innerServices.BuildServiceProvider().GetService<IRepositoryServicesCollection>();
            innerServices.AddRepositoryService<BookingEntity, BookingModel>(collection);
            innerServices.AddRepositoryService<GuestEntity, GuestModel>(collection);
            innerServices.AddRepositoryService<ServiceEntity, ServiceModel>(collection);
            innerServices.AddRepositoryService<ServiceTypeEntity, ServiceTypeModel>(collection);
            innerServices.AddRepositoryService<UserFeedbackEntity, UserFeedbackModel>(collection);
            innerServices.AddRepositoryService<StaffEntity, StaffModel>(collection);
            innerServices.AddRepositoryService<PositionTypeEntity, PositionTypeModel>(collection);
        }
        private static void AddRepositoryService<TEntity, TModel>(this IServiceCollection services, IRepositoryServicesCollection collection)
            where TEntity : Entity
            where TModel : Model
        {            
            services.AddScoped<IRepositoryServiceAsync<TEntity, TModel>, RepositoryService<TEntity, TModel>>();
            IRepositoryServiceAsync<TEntity, TModel> item =  innerServices.BuildServiceProvider().GetService<IRepositoryServiceAsync<TEntity, TModel>>();
            collection.Add(item);
        }
        public static void CreateHotels(HotelDbContext hotelDbContext)
        {
            hotelDbContext.Database.EnsureCreated();
            RoomTypeEntity Economy = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Эконом",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity StdOneBed = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Стандарт с одной двухспальной кроватью",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity StdTwoBeds = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Стандарт с двумя кроватями",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity Superior = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Супериор с одной двухспальной кроватью",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity Studio = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Студия",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity Apts = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Аппартаменты",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity Lux = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Люкс",
                Rooms = new List<RoomEntity>()
            };
            RoomTypeEntity President = new RoomTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Люкс",
                Rooms = new List<RoomEntity>()
            };
             List<RoomTypeEntity> roomTypeModels = new List<RoomTypeEntity>() { Economy, StdOneBed, StdTwoBeds, Superior, Studio, Apts, Lux, President };

            RoomViewEntity NoWindow = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Нет окон",
                Rooms = new List<RoomEntity>()
            };
            RoomViewEntity Blocked = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Загорожен",
                Rooms = new List<RoomEntity>()
            };
            RoomViewEntity Sightseen = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "На достопримечательность",
                Rooms = new List<RoomEntity>()
            };
            RoomViewEntity Nature = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Природный",
                Rooms = new List<RoomEntity>()
            };
            RoomViewEntity Urban = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Городской",
                Rooms = new List<RoomEntity>()
            };
            RoomViewEntity Other = new RoomViewEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Не определен",
                Rooms = new List<RoomEntity>()
            };

            List<RoomViewEntity> roomViewModels = new List<RoomViewEntity>() { NoWindow, Blocked, Sightseen, Nature, Urban, Other };

            RoomEntity Room1 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = NoWindow,
                ViewId = NoWindow.Id,
                RoomType = Economy,
                RoomTypeId = Economy.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room2 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Blocked,
                ViewId = Blocked.Id,
                RoomType = Economy,
                RoomTypeId = Economy.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room3 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Urban,
                ViewId = Urban.Id,
                RoomType = StdOneBed,
                RoomTypeId = StdOneBed.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room4 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Nature,
                ViewId = Nature.Id,
                RoomType = StdOneBed,
                RoomTypeId = StdOneBed.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room5 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Urban,
                ViewId = Urban.Id,
                RoomType = StdTwoBeds,
                RoomTypeId = StdTwoBeds.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room6 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Nature,
                ViewId = Nature.Id,
                RoomType = StdTwoBeds,
                RoomTypeId = StdTwoBeds.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room7 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Urban,
                ViewId = Urban.Id,
                RoomType = Superior,
                RoomTypeId = Superior.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room8 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Sightseen,
                ViewId = Sightseen.Id,
                RoomType = Superior,
                RoomTypeId = Superior.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room9 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Sightseen,
                ViewId = Sightseen.Id,
                RoomType = Lux,
                RoomTypeId = Lux.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room10 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Nature,
                ViewId = Nature.Id,
                RoomType = Lux,
                RoomTypeId = Lux.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            RoomEntity Room11 = new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Price = 2000,
                Area = 15,
                Rating = 0,
                View = Sightseen,
                ViewId = Sightseen.Id,
                RoomType = President,
                RoomTypeId = President.Id,
                Capacity = 2,
                Bookings = new List<BookingEntity>()
            };
            Economy.Rooms = new List<RoomEntity>() { Room1, Room2 };
            StdOneBed.Rooms = new List<RoomEntity>() { Room3, Room4 };
            StdTwoBeds.Rooms = new List<RoomEntity>() { Room5, Room6 };
            Superior.Rooms = new List<RoomEntity>() { Room7, Room8 };
            Lux.Rooms = new List<RoomEntity>() { Room9, Room10 };
            President.Rooms = new List<RoomEntity>() { Room11 };

            NoWindow.Rooms = new List<RoomEntity>() { Room1 };
            Blocked.Rooms = new List<RoomEntity>() { Room2 };
            Urban.Rooms = new List<RoomEntity>() { Room3, Room5, Room7 };
            Nature.Rooms = new List<RoomEntity>() { Room4, Room6, Room10 };
            Sightseen.Rooms = new List<RoomEntity>() { Room8, Room9, Room11 };

            List<RoomEntity> rooms = new List<RoomEntity>() { Room1, Room2, Room3, Room4, Room5, Room6, Room7, Room8, Room9, Room10,Room11 };

            ServiceTypeEntity Meal = new ServiceTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Питание",
                Services = new List<ServiceEntity>()
            };
            ServiceTypeEntity Spa = new ServiceTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "СПА",
                Services = new List<ServiceEntity>()
            };
            ServiceTypeEntity Transfer = new ServiceTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Трансфер",
                Services = new List<ServiceEntity>()
            };
            ServiceTypeEntity Excursion = new ServiceTypeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Экскурсия",
                Services = new List<ServiceEntity>()
            };



            List<ServiceTypeEntity> serviceTypeModels = new List<ServiceTypeEntity>() { Meal, Spa, Transfer, Excursion };

            ServiceEntity Breakfast = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Завтрак",
                Price = 400,
                ServiceType = Meal,
                ServiceTypeId = Meal.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity Dinner = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Ужин",
                Price = 600,
                ServiceType = Meal,
                ServiceTypeId = Meal.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity Massage = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Массаж",
                Price = 1000,
                ServiceType = Spa,
                ServiceTypeId = Spa.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity Sauna = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Баня",
                Price = 800,
                ServiceType = Spa,
                ServiceTypeId = Spa.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity FromAirport = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Трансфер от аэропорта",
                Price = 2000,
                ServiceType = Transfer,
                ServiceTypeId = Transfer.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity ToAirport = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Трансфер от аэропорта",
                Price = 2000,
                ServiceType = Transfer,
                ServiceTypeId = Transfer.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity SightseenExcursionSPb = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Обзорная экскурсия по Санкт-Петербургу",
                Price = 2000,
                ServiceType = Excursion,
                ServiceTypeId = Excursion.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };
            ServiceEntity RoofsExcursionSPb = new ServiceEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Экскурсия по крышам Санкт-Петербурга",
                Price = 1500,
                ServiceType = Excursion,
                ServiceTypeId = Excursion.Id,
                Bookings = new List<BookingEntity>(),
                Hotels = new List<HotelEntity>()
            };

            List<ServiceEntity> services = new List<ServiceEntity>() { Breakfast, Dinner, Massage, Sauna, FromAirport, ToAirport, SightseenExcursionSPb, RoofsExcursionSPb };
            Meal.Services = new List<ServiceEntity>() { Breakfast, Dinner };
            Spa.Services = new List<ServiceEntity>() { Massage, Sauna };
            Transfer.Services = new List<ServiceEntity>() { FromAirport, ToAirport };
            Excursion.Services = new List<ServiceEntity>() { SightseenExcursionSPb, RoofsExcursionSPb };

            HotelEntity hotel = new HotelEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Chebebe Bolshaya Morskaya",
                Location = "г. Санкт-Петербург",
                Rating = 0,
                Stars = 4,
                Rooms = rooms,
                Services = services
            };
            rooms.ForEach(i => i.Hotel = hotel);
            rooms.ForEach(i => i.HotelId = hotel.Id);

            services.ForEach(i => i.Hotels.Add(hotel));
            var tt = hotel.ToModel();
            hotelDbContext.Hotels.Add(hotel);
            hotelDbContext.Rooms.AddRange(rooms);
            hotelDbContext.RoomTypes.AddRange(roomTypeModels);
            hotelDbContext.Services.AddRange(services);
            hotelDbContext.ServiceTypes.AddRange(serviceTypeModels);
            hotelDbContext.RoomViews.AddRange(roomViewModels);
            

            PositionTypeModel Director = new PositionTypeModel(Guid.NewGuid(), "Директор");
            PositionTypeModel ViceDirector = new PositionTypeModel(Guid.NewGuid(), "Заместитель Директора");
            PositionTypeModel Receptionist = new PositionTypeModel(Guid.NewGuid(), "Администратор стойки регистрации");
            PositionTypeModel Maid = new PositionTypeModel(Guid.NewGuid(), "Горничная");
            PositionTypeModel LobbyBoy = new PositionTypeModel(Guid.NewGuid(), "Коридорный");
            PositionTypeModel SeniorСoncierge = new PositionTypeModel(Guid.NewGuid(), "Старший консьерж");
            PositionTypeModel Waiter = new PositionTypeModel(Guid.NewGuid(), "Официант");
            PositionTypeModel Bartender = new PositionTypeModel(Guid.NewGuid(), "Бармен");
            PositionTypeModel SecurityGuard = new PositionTypeModel(Guid.NewGuid(), "Охранник");

            List<PositionTypeModel> positionTypeModels = new List<PositionTypeModel>() { Director, ViceDirector, Receptionist, Maid, LobbyBoy, SeniorСoncierge, Waiter, Bartender, SecurityGuard };
            hotelDbContext.PositionTypes.AddRange(positionTypeModels.ConvertAll(i => i.ToEntity()));

            GenderModel genderModel1 = new GenderModel(Guid.NewGuid(), Genders.none);
            GenderModel genderModel2 = new GenderModel(Guid.NewGuid(), Genders.Mele);
            GenderModel genderModel3 = new GenderModel(Guid.NewGuid(), Genders.Female);

            List<GenderEntity> genderEntities = new List<GenderModel>() { genderModel1, genderModel2, genderModel3 }.ConvertAll(i => i.ToEntity());
            hotelDbContext.Genders.AddRange(genderEntities);

           // hotelDbContext.SaveChanges();
        }   
    }
}