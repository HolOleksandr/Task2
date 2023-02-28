using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTO;
using Business.RequestModels;
using Data.Entities;

namespace Business.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Book, BookListDto>()
                .ForMember(b => b.RewiewsNumber, x => x.MapFrom(y => y.Reviews.Count))
                .ForMember(b => b.Rating, x => x.MapFrom(y => y.Ratings.Select(r => r.Score).DefaultIfEmpty(0).Average()));

            CreateMap<Book, BookDetailsDto>()
                .ForMember(b => b.Reviews, x => x.MapFrom(y => y.Reviews))
                .ForMember(b => b.Rating, x => x.MapFrom(y => y.Ratings.Select(r => r.Score).DefaultIfEmpty(0).Average()));

            CreateMap<Book, BookRequestModel>().ReverseMap();
            CreateMap<Review, ReviewRequestModel>().ReverseMap();
            CreateMap<Rating, RatingRequestModel>().ReverseMap();

        }
    }
}
