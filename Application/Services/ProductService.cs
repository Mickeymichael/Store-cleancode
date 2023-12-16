using Application.Interfaces;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }



        public async Task<bool> CreateProduct(Product product)
        {
            if (product!=null)
            {
               await _unitOfWork.Products.Add(product);
                var result = _unitOfWork.Save();
                if (result>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

            
        }

        public async Task<bool> DeleteProduct(int id)
        {

            if (id>0)
            {
                var prod = await _unitOfWork.Products.GetById(id);
                if (prod!=null)
                {
                    _unitOfWork.Products.Delete(prod);
                    var result=_unitOfWork.Save();
                    if (result>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return products;
          
        }

        public async Task<Product> GetProductById(int id)
        {
            if (id > 0)
            {
                var prod = await _unitOfWork.Products.GetById(id);
                if (prod!=null)
                {
                    return prod;
                }
            }
            return null;
        }
        public async Task<bool> UpdateProduct(Product productDto)
        {
            if (productDto != null)
            {
                var prod=await _unitOfWork.Products.GetById(productDto.Id);
                if (prod!=null)
                {
                    prod.ProductName= productDto.ProductName;
                    prod.ProductDescription= productDto.ProductDescription;
                    prod.ProductStock=productDto.ProductStock;
                    prod.ProductPricelistId = productDto.ProductPricelistId;
                    _unitOfWork.Products.Update(prod);
                    var result=_unitOfWork.Save();
                    if (result>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }
    }
}
