using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class CartService : BaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>, ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly ICartItemRepo _cartItemRepo;

        
        public CartService(ICartRepo cartRepo, ICartItemRepo cartItemRepo, IMapper mapper) : base(cartRepo, mapper)
        {
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
        }

        public async Task<CartReadDto> AddToCart(CartCreateDto createDto)
        {

            var foundItem = await _cartRepo.GetUserCartDetails(createDto.UserId.Value);
            if (foundItem == null)
            {
                var cartData = _mapper.Map<Cart>(createDto);
                cartData.IsActive = true;
                var entity = await _cartRepo.CreateOne(cartData);
              
                var cartItems = _mapper.Map<CartItem>(createDto.CartItem);
                cartItems.CartId = entity.Id;
                cartItems.IsActive = true;
                await _cartItemRepo.CreateOne(cartItems);
                return await this.GetUserCartDetails(createDto.UserId.Value);
            }
            else
            {
                var isProductAlreadyAdded = foundItem.CartItem.Find(x=>x.ProductId==createDto.CartItem.ProductId && x.IsActive == true);
                 
                if(isProductAlreadyAdded!=null) //same product is already added before
                {
                    isProductAlreadyAdded.Quantity += createDto.CartItem.Quantity; //   in thi case only add quantity
                    await _cartItemRepo.UpdateOneById(isProductAlreadyAdded);
                }
                else //new product is being added
                {
                    var cartItemDto = _mapper.Map<CartItem>(createDto.CartItem);
                    cartItemDto.CartId = foundItem.Id;
                    cartItemDto.IsActive = true;
                    await _cartItemRepo.CreateOne(cartItemDto);
                }
                
                return await this.GetUserCartDetails(createDto.UserId.Value);
            }
        }

        public async Task<CartReadDto> GetUserCartDetails(Guid UserId)
        {
            var foundItem = _cartRepo.GetUserCartDetails(UserId);
            decimal TotalAmount = 0;
            if (foundItem.Result != null){
                foreach (var cartItem in foundItem.Result.CartItem){
                    TotalAmount += cartItem.Product.Price * cartItem.Quantity;
                }
                var userCart =   _mapper.Map<CartReadDto>(foundItem.Result);
                userCart.TotalAmount = TotalAmount;
                return userCart;
            }
            else{
                return null;
            }
            
        }
        public async Task<CartReadDto> RemoveProductFromCart(Guid ProductId, Guid UserId)
        {                 
            var foundItem = _cartRepo.GetUserCartDetails(UserId);
            if (foundItem.Result == null){
                return null;
            }
            var productToBeRemoved = foundItem.Result.CartItem.Find(x=>x.ProductId==ProductId && x.IsActive == true);
                 
            if(productToBeRemoved!=null) //check if there's removable cart item
            {
                productToBeRemoved.IsActive=false;
                await _cartItemRepo.UpdateOneById(productToBeRemoved);
            }
            if(foundItem.Result.CartItem.Count==1) // check if there was only one active item
            {
                foundItem.Result.IsActive = false;
                var entity = await _cartRepo.UpdateOneById(foundItem.Result);
            }
            return await this.GetUserCartDetails(UserId);
        }
    }
}