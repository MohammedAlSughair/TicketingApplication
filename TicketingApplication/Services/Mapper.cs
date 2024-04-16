using AutoMapper;
using TicketingApplication.Repository;
using TicketingApplication.Entities;
using TicketingApplication.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketingApplication.Services
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<Tickets, TicketsViewModel>().ReverseMap();
			CreateMap<TicketTransaction, TicketTransactionViewModel>().ReverseMap();
			CreateMap<User, UserViewModel>().ReverseMap();
			CreateMap<Tags, TagsViewModel>().ReverseMap();
			CreateMap<Areas, AreasViewModel>().ReverseMap();
			CreateMap<Cities, CitiesViewModel>().ReverseMap();
			CreateMap<Countries, CountriesViewModel>().ReverseMap();
			CreateMap<CustomerBranch, CustomerBranchViewModel>().ReverseMap();
			CreateMap<CustomerLocation, CustomerLocationViewModel>().ReverseMap();
			CreateMap<Customers, CustomersViewModel>().ReverseMap();
			CreateMap<Technicians, TechniciansViewModel>().ReverseMap();
			CreateMap<CustomerBranch, CustomerBranchViewModel>().ReverseMap();

		}
	}
}
