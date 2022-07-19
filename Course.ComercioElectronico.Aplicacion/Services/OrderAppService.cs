using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class OrderAppService : IOrderAppService
    {
        protected IOrderRepository repository { get; set; }
        protected IProductAppService productService { get; set; }
        private readonly IValidator<CreateOrderDto> validator;

        public OrderAppService(IOrderRepository repository, IValidator<CreateOrderDto> validator, IProductAppService productService)
        {
            this.repository = repository;
            this.validator = validator;
            this.productService = productService;
        }

        public async Task<ICollection<OrderDto>> GetAllAsync()
        {
            var query = this.repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false)
                .Select(x => new OrderDto
                    {
                        DeliveryMethodId = x.DeliveryMethodId,
                        Code = x.Code,
                        DeliveryMethodName = x.DeliveryMethod.Description,
                        CartItems = (List<CartItemDto>)x.ProductDetail.Where(y => y.CartOrderId == x.Code)
                            .Select(item => new CartItemDto
                            {
                                Code = item.Code,
                                ProductId = item.ProductId,
                                ProductName = item.Product.Name,
                                Quantity = item.Quantity,
                                CartOrderId = item.CartOrderId

                            })
                }
                );
            
            return result.ToList();
          
        }

        public async Task<ICollection<CartItemDto>> GetAllItemsAsync()
        {
            var query = this.repository.GetQueryableItems();
            var result = query.Where(x => x.IsDeleted == false)
                .Select(x => new CartItemDto
                {
                    Code = x.Code,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    CartOrderId = x.CartOrderId,
                }
                );
            return result.ToList();
        }
        
        public async Task<OrderDto> CreateAsync(CreateOrderDto createrderDto)
        {
            var newOrder = new CartOrder
            {
                Code = createrderDto.Code,
                DeliveryMethodId = createrderDto.DeliveryMethodId,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            await this.repository.CreateCartOrderAsync(newOrder);

            foreach (var item in createrderDto.ItemsToCart)
            {
                //Validation of stock
                var query = this.repository.GetQueryable();
                var stockValidation = query.Select(x => x.ProductDetail
                .Where(y => y.ProductId == item.ProductId)
                .Select(y => y.Product.Stock)).FirstOrDefault();

                foreach (var stock in stockValidation)
                {
                    if(stock > 0)
                    {
                        var newCartItem = new CartItemOrder
                        {
                            Code = item.Code,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            CartOrderId = createrderDto.Code,
                            CreationDate = DateTime.Now,
                            IsDeleted = false
                        };

                        //UpdateStockProduct(item.ProductId, item.Quantity);

                        await this.repository.CreateCartItemOrderAsync(newCartItem);
                    }
                }
            }
            return await GetByIdAsync(createrderDto.Code);
            
        }

        public async void UpdateStockProduct(Guid id, int quantity)
        {
            var product = await this.productService.GetByIdAsync(id);

            var newProduct = new CreateProductDto
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock - quantity,
                ProductyTypeId = product.ProductyTypeId,
                BrandId = product.BrandId
            };

            await productService.UpdateAsync(newProduct, id);
        }

        public async Task<OrderDto> GetByIdAsync(string id)
        {
            var query = this.repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false && x.Code == id)
                .Select(x => new OrderDto
                {
                    DeliveryMethodId = x.DeliveryMethodId,
                    Code = x.Code,
                    DeliveryMethodName = x.DeliveryMethod.Description,
                    CartItems = (List<CartItemDto>)x.ProductDetail.Where(y => y.CartOrderId == x.Code)
                    .Select(item => new CartItemDto
                    {
                        Code = item.Code,
                        ProductId= item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        CartOrderId = item.CartOrderId

                    })
                }
                );

            return await result.SingleOrDefaultAsync();
        }

        public async Task<OrderDto> UpdateAsync(UpdateOrderDto createOrderDto, string id)
        {
            var query = this.repository.GetQueryable();
            var cartOrder = await query.Where(x => x.Code == id).SingleOrDefaultAsync();
            cartOrder.DeliveryMethodId = createOrderDto.DeliveryMethodId;
            cartOrder.ModifiedDate = DateTime.Now;

            foreach (var item in createOrderDto.ItemsToCart)
            {
                var newCartItemOrder = new CartItemOrder
                {
                    Code = item.Code,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    CartOrderId = id,
                    ModifiedDate = DateTime.Now,
                    IsDeleted = false
                };
                
                await repository.UpdateCartItemOrder(newCartItemOrder);
            }

            await repository.UpdateCartOrder(cartOrder);
            return await GetByIdAsync(id);
        }

        public async Task<ResultPagination<OrderDto>> GetListAsync(int limit = 10, int offset = 0, string sort = "Code", string order = "asc")
        {
            var query = repository.GetQueryable();

            //Filtrando los eliminados
            query = query.Where(x => x.IsDeleted == false);

            //1. Total
            var total = await query.CountAsync();
            //2. Pagination
            query = query
                .Skip(offset)
                .Take(limit);

            //3. Order
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToUpper())
                {
                    case "CODE":
                        query = query.OrderBy(x => x.Code);
                        break;
                    default:
                        throw new ArgumentException($"The parameter sort {sort} not support");
                        break;
                }
            }

            var queryDto = query.Select(x => new OrderDto()
            {
                DeliveryMethodId = x.DeliveryMethodId,
                Code = x.Code,
                DeliveryMethodName = x.DeliveryMethod.Description,
                CartItems = (List<CartItemDto>)x.ProductDetail.Where(y => y.CartOrderId == x.Code)
                    .Select(item => new CartItemDto
                    {
                        Code = item.Code,
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        CartOrderId = item.CartOrderId

                    })
            });

            var items = await queryDto.ToListAsync();
            var result = new ResultPagination<OrderDto>();
            result.Total = total;
            result.Items = items;
            return result;
        }

        public async Task<List<IEnumerable<CartItemDto>>> GetByBrandAndId(string id, string brandId)
        {
            var query = this.repository.GetQueryable();
            
            var result = await query.Where(x=> x.IsDeleted == false && x.Code == id)
                .Select(x=> x.ProductDetail
                .Where(y=>y.Product.BrandId ==brandId)
                .Select(y=>new CartItemDto
                {
                    Code=y.Code,
                    ProductId = y.ProductId,
                    ProductName = y.Product.Name,
                    Quantity = y.Quantity,
                    CartOrderId = y.CartOrderId
                }))
                .ToListAsync();

            return result;

        }

        public async Task<List<IEnumerable<CartItemDto>>> GetByProductTypeAndId(string id, string productTypeId)
        {
            var query = this.repository.GetQueryable();

            var result = await query.Where(x => x.IsDeleted == false && x.Code == id)
                .Select(x => x.ProductDetail
                .Where(y => y.Product.ProductTypeId == productTypeId)
                .Select(y => new CartItemDto
                {
                    Code = y.Code,
                    ProductId = y.ProductId,
                    ProductName = y.Product.Name,
                    Quantity = y.Quantity,
                    CartOrderId = y.CartOrderId
                }))
                .ToListAsync();

            return result;
        }
    }
}
