using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using BlockchainHotelBooking.Contracts.HotelBooking.ContractDefinition;

namespace BlockchainHotelBooking.Contracts.HotelBooking
{
    public partial class HotelBookingService: HotelBookingServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, HotelBookingDeployment hotelBookingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<HotelBookingDeployment>().SendRequestAndWaitForReceiptAsync(hotelBookingDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, HotelBookingDeployment hotelBookingDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<HotelBookingDeployment>().SendRequestAsync(hotelBookingDeployment);
        }

        public static async Task<HotelBookingService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, HotelBookingDeployment hotelBookingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, hotelBookingDeployment, cancellationTokenSource);
            return new HotelBookingService(web3, receipt.ContractAddress);
        }

        public HotelBookingService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class HotelBookingServiceBase: ContractWeb3ServiceBase
    {

        public HotelBookingServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> BookRoomRequestAsync(BookRoomFunction bookRoomFunction)
        {
             return ContractHandler.SendRequestAsync(bookRoomFunction);
        }

        public virtual Task<TransactionReceipt> BookRoomRequestAndWaitForReceiptAsync(BookRoomFunction bookRoomFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(bookRoomFunction, cancellationToken);
        }

        public virtual Task<string> BookRoomRequestAsync(BigInteger roomNumber)
        {
            var bookRoomFunction = new BookRoomFunction();
                bookRoomFunction.RoomNumber = roomNumber;
            
             return ContractHandler.SendRequestAsync(bookRoomFunction);
        }

        public virtual Task<TransactionReceipt> BookRoomRequestAndWaitForReceiptAsync(BigInteger roomNumber, CancellationTokenSource cancellationToken = null)
        {
            var bookRoomFunction = new BookRoomFunction();
                bookRoomFunction.RoomNumber = roomNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(bookRoomFunction, cancellationToken);
        }

        public Task<BigInteger> BookingCountQueryAsync(BookingCountFunction bookingCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BookingCountFunction, BigInteger>(bookingCountFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> BookingCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BookingCountFunction, BigInteger>(null, blockParameter);
        }

        public virtual Task<BookingsOutputDTO> BookingsQueryAsync(BookingsFunction bookingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<BookingsFunction, BookingsOutputDTO>(bookingsFunction, blockParameter);
        }

        public virtual Task<BookingsOutputDTO> BookingsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var bookingsFunction = new BookingsFunction();
                bookingsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<BookingsFunction, BookingsOutputDTO>(bookingsFunction, blockParameter);
        }

        public virtual Task<string> CancelBookingRequestAsync(CancelBookingFunction cancelBookingFunction)
        {
             return ContractHandler.SendRequestAsync(cancelBookingFunction);
        }

        public virtual Task<TransactionReceipt> CancelBookingRequestAndWaitForReceiptAsync(CancelBookingFunction cancelBookingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelBookingFunction, cancellationToken);
        }

        public virtual Task<string> CancelBookingRequestAsync(BigInteger bookingId)
        {
            var cancelBookingFunction = new CancelBookingFunction();
                cancelBookingFunction.BookingId = bookingId;
            
             return ContractHandler.SendRequestAsync(cancelBookingFunction);
        }

        public virtual Task<TransactionReceipt> CancelBookingRequestAndWaitForReceiptAsync(BigInteger bookingId, CancellationTokenSource cancellationToken = null)
        {
            var cancelBookingFunction = new CancelBookingFunction();
                cancelBookingFunction.BookingId = bookingId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelBookingFunction, cancellationToken);
        }

        public virtual Task<string> ConfirmBookingRequestAsync(ConfirmBookingFunction confirmBookingFunction)
        {
             return ContractHandler.SendRequestAsync(confirmBookingFunction);
        }

        public virtual Task<TransactionReceipt> ConfirmBookingRequestAndWaitForReceiptAsync(ConfirmBookingFunction confirmBookingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmBookingFunction, cancellationToken);
        }

        public virtual Task<string> ConfirmBookingRequestAsync(BigInteger bookingId)
        {
            var confirmBookingFunction = new ConfirmBookingFunction();
                confirmBookingFunction.BookingId = bookingId;
            
             return ContractHandler.SendRequestAsync(confirmBookingFunction);
        }

        public virtual Task<TransactionReceipt> ConfirmBookingRequestAndWaitForReceiptAsync(BigInteger bookingId, CancellationTokenSource cancellationToken = null)
        {
            var confirmBookingFunction = new ConfirmBookingFunction();
                confirmBookingFunction.BookingId = bookingId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmBookingFunction, cancellationToken);
        }

        public Task<string> HotelOwnerQueryAsync(HotelOwnerFunction hotelOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HotelOwnerFunction, string>(hotelOwnerFunction, blockParameter);
        }

        
        public virtual Task<string> HotelOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HotelOwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> RoomPriceQueryAsync(RoomPriceFunction roomPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoomPriceFunction, BigInteger>(roomPriceFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> RoomPriceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoomPriceFunction, BigInteger>(null, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(BookRoomFunction),
                typeof(BookingCountFunction),
                typeof(BookingsFunction),
                typeof(CancelBookingFunction),
                typeof(ConfirmBookingFunction),
                typeof(HotelOwnerFunction),
                typeof(RoomPriceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(BookingCancelledEventDTO),
                typeof(BookingConfirmedEventDTO),
                typeof(RoomBookedEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {

            };
        }
    }
}
