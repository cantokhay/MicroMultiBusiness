// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MicroMultiBusiness.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadOnly"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImage"){Scopes={"ImageFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Has been full authorized for catalog operations"),
            new ApiScope("CatalogReadOnly","Has been read only authorized for catalog operations"),
            new ApiScope("DiscountFullPermission","Has been full authorized for discount operations"),
            new ApiScope("OrderFullPermission","Has been full authorized for order operations"),
            new ApiScope("CargoFullPermission","Has been full authorized for cargo operations"),
            new ApiScope("BasketFullPermission","Has been full authorized for basket operations"),
            new ApiScope("CommentFullPermission","Has been full authorized for comment operations"),
            new ApiScope("PaymentFullPermission","Has been full authorized for payment operations"),
            new ApiScope("ImageFullPermission","Has been full authorized for image operations"),
            new ApiScope("OcelotFullPermission","Has been full authorized for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="MicroMultiBusinessVisitorId",
                ClientName ="MicroMultiBusiness Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("MicroMultiBusinessSecretKey".Sha256())},
                AllowedScopes = {"CatalogReadOnly", "CatalogFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission", "OcelotFullPermission" }
            },
            new Client
            {
                ClientId="MicroMultiBusinessManagerId",
                ClientName="MicroMultiBusiness Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("MicroMultiBusinessSecretKey".Sha256())},
                AllowedScopes = {"CatalogFullPermission", "CatalogReadOnly", "BasketFullPermission", "CommentFullPermission", "ImageFullPermission", "PaymentFullPermission", "OcelotFullPermission" ,
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId="MicroMultiBusinessAdminId",
                ClientName="MicroMultiBusiness Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("MicroMultiBusinessSecretKey".Sha256())},
                AllowedScopes = {"CatalogFullPermission", "CatalogReadOnly","DiscountFullPermission", "OrderFullPermission","CargoFullPermission", "BasketFullPermission","CommentFullPermission", "PaymentFullPermission","ImageFullPermission", "OcelotFullPermission" ,
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}