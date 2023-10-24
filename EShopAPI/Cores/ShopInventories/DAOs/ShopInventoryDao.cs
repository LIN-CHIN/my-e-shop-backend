using EShopAPI.Context;
using EShopAPI.Cores.ShopInventories.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Cores.ShopInventories.DAOs
{
    /// <summary>
    /// /// <summary>
    /// 商店庫存 DAO 
    /// </summary>
    /// </summary>
    public class ShopInventoryDao : IShopInventoryDao
    {
        private readonly EShopContext _eShopContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eShopContext"></param>
        public ShopInventoryDao(EShopContext eShopContext) 
        {
            _eShopContext = eShopContext;
        }

        ///<inheritdoc/>
        public IQueryable<ShopInventory> Get(QueryShopInventoryDto queryDto)
        {
            IQueryable<ShopInventory> shopInventories = _eShopContext.ShopInventories;
            
            if (!string.IsNullOrWhiteSpace(queryDto.Number)) 
            {
                shopInventories = shopInventories
                    .Where(si => EF.Functions.Like(si.Number, $"%{si.Number}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Name))
            {
                shopInventories = shopInventories
                    .Where(si => EF.Functions.Like(si.Name, $"%{si.Name}%"));
            }

            if (queryDto.InventoryQuantity != null)
            {
                shopInventories = shopInventories
                    .Where(si => si.InventoryQuantity == queryDto.InventoryQuantity);
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Supplier))
            {
                shopInventories = shopInventories
                    .Where(si => EF.Functions.Like(si.Supplier!, $"%{si.Supplier}%"));
            }

            if (!string.IsNullOrWhiteSpace(queryDto.Brand))
            {
                shopInventories = shopInventories
                    .Where(si => EF.Functions.Like(si.Brand!, $"%{si.Brand}%"));
            }

            if (queryDto.ProductType != null)
            {
                shopInventories = shopInventories
                    .Where(si => si.ProductType == queryDto.ProductType);
            }

            if (queryDto.IsComposite != null)
            {
                shopInventories = shopInventories
                    .Where(si => si.IsComposite == queryDto.IsComposite);
            }

            if (queryDto.IsCompositeOnly != null)
            {
                shopInventories = shopInventories
                    .Where(si => si.IsCompositeOnly == queryDto.IsCompositeOnly);
            }

            if (queryDto.IsEnable != null)
            {
                shopInventories = shopInventories
                    .Where(si => si.IsEnable == queryDto.IsEnable);
            }

            return shopInventories;
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByIdAsync(long id)
        {
            return await _eShopContext.ShopInventories
                .Where(si => si.Id == id)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByNumberAsync(string number)
        {
            return await _eShopContext.ShopInventories
                .Where(si => si.Number == number)
                .SingleOrDefaultAsync();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> InsertAsync(ShopInventory shopInventory)
        {
            _eShopContext.ShopInventories.Add(shopInventory);
            await _eShopContext.SaveChangesAsync();
            return shopInventory;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(ShopInventory shopInventory)
        {
            _eShopContext.ShopInventories.Update(shopInventory);
            await _eShopContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(ShopInventory shopInventory)
        {
            _eShopContext.ShopInventories.Remove(shopInventory);
            await _eShopContext.SaveChangesAsync();
        }
    }
}
