﻿using EShopAPI.Context;
using EShopAPI.Cores.ShopRoles.DAOs;
using EShopAPI.Cores.ShopRoles.DTOs;
using EShopAPI.Cores.ShopUsers;
using EShopCores.Errors;
using EShopCores.Responses;

namespace EShopAPI.Cores.ShopRoles.Services
{
    /// <summary>
    /// 商店角色 Service Interface
    /// </summary>
    public class ShopRoleService : IShopRoleService
    {
        private readonly IShopRoleDao _shopRoleDao;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopRoleDao"></param>
        public ShopRoleService(IShopRoleDao shopRoleDao) 
        {
            _shopRoleDao = shopRoleDao;
        }

        ///<inheritdoc/>
        public IQueryable<ShopRole> Get(QueryShopRoleDto queryDto)
        {
            return _shopRoleDao.Get(queryDto);
        }

        ///<inheritdoc/>
        public async Task<ShopRole?> GetByIdAsync(long id)
        {
            return await _shopRoleDao.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public async Task<ShopRole> ThrowNotFindByIdAsync(long id)
        {
            ShopRole? shopRole = await _shopRoleDao.GetByIdAsync(id);

            if (shopRole == null)
            {
                throw new EShopException(
                    ResponseCodeType.RequestParameterError,
                    $"找不到該id: {id}");
            }

            return shopRole;
        }

        ///<inheritdoc/>
        public async Task ThrowExistByNumberAsync(string number)
        {
            ShopRole? shopRole = await _shopRoleDao.GetByNumberAsync(number);

            if (shopRole != null)
            {
                throw new EShopException(ResponseCodeType.DuplicateData, "帳號已存在");
            }
        }

        ///<inheritdoc/>
        public async Task<ShopRole> InsertAsync(InsertShopRoleDto insertDto)
        {
            await ThrowExistByNumberAsync(insertDto.Number);
            return await _shopRoleDao.InsertAsync(insertDto.ToEntity());
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateShopRoleDto updateDto)
        {
            ShopRole shopRole = await ThrowNotFindByIdAsync(updateDto.Id);
            await _shopRoleDao.UpdateAsync(updateDto.SetEntity(shopRole));
        }

        ///<inheritdoc/>
        public async Task EnableAsync(long id, bool isEnable)
        {
            ShopRole shopRole = await ThrowNotFindByIdAsync(id);
            shopRole.IsEnable = isEnable;
            await _shopRoleDao.UpdateAsync(shopRole);
        }
    }
}
