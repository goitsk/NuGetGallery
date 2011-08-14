﻿using System;

namespace NuGetGallery {
    public interface IUserService {
        User Create(
            string username,
            string password,
            string emailAddress);

        User FindByApiKey(Guid apiKey);

        User FindByEmailAddress(string emailAddress);

        User FindByUsername(string username);

        User FindByUsernameAndPassword(
            string username,
            string password);
    }
}