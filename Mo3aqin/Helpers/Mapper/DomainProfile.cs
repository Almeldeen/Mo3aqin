using AutoMapper;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Helpers.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<Employee, Employee_VM>();
            CreateMap<Employee_VM,Employee >();

            CreateMap<GameDetails, GameDetail_VM>();
            CreateMap<GameDetail_VM, GameDetails>();

            CreateMap<Player, Player_VM>();
            CreateMap<Player_VM, Player>();
        }
    }
}
