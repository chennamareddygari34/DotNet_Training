﻿using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
