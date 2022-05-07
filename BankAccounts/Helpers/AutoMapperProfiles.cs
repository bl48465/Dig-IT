using AutoMapper;
using BankAccounts.Models;
using BankAccounts.Models.DTOs;

namespace BankAccounts.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, UserDTO>();
        CreateMap<RegisterDTO, User>();
        CreateMap<Transaction, TransactionDTO>();
    }
}
