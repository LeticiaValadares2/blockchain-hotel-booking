using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;
using BlockchainHotelBooking.Contracts.HotelBooking.ContractDefinition;

namespace BlockchainHotelBooking.Contracts.HotelBooking.ContractDefinition
{


    public partial class HotelBookingDeployment : HotelBookingDeploymentBase
    {
        public HotelBookingDeployment() : base(BYTECODE) { }
        public HotelBookingDeployment(string byteCode) : base(byteCode) { }
    }

    public class HotelBookingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60808060405234603257670de0b6b3a76400006001555f80546001600160a01b031916331790556105bb90816100378239f35b5f80fdfe60808060405260033611610011575f80fd5b5f3560e01c9081630dca825e146103d5575080631dab301e1461037557806354056b69146102715780635f49d3d8146100cd5780636c036162146100b05780636d759172146100935763b173616b14610068575f80fd5b3461008f575f36600319011261008f575f546040516001600160a01b039091168152602090f35b5f80fd5b3461008f575f36600319011261008f576020600354604051908152f35b3461008f575f36600319011261008f576020600154604051908152f35b602036600319011261008f57600435801561023d576001543403610204576003545f1981146101f0576001019081600355604051608081019080821067ffffffffffffffff8311176101dc576003916040523381526020810183815260408201903482526060830195600187525f52600260205260405f209260018060a01b039051166bffffffffffffffffffffffff60a01b8454161783555160018301555160028201550191519060048210156101c8577f2b4708ffb84be173b818d9b07f07c6679aa34f2f03fa0763b98034f6fc694fe59260609260ff80198354169116179055600354906040519182523360208301526040820152a1005b634e487b7160e01b5f52602160045260245ffd5b634e487b7160e01b5f52604160045260245ffd5b634e487b7160e01b5f52601160045260245ffd5b60405162461bcd60e51b8152602060048201526011602482015270125b98dbdc9c9958dd081c185e5b595b9d607a1b6044820152606490fd5b60405162461bcd60e51b815260206004820152600c60248201526b496e76616c696420726f6f6d60a01b6044820152606490fd5b3461008f57602036600319011261008f575f54600435906001600160a01b0316330361033d57805f52600260205260ff600360405f2001541660048110156101c857600103610300576020817f853fc6307cc2d72d0ec45ec77f198703d63dd760dedc66cf5488bc9727d69f9c925f5260028252600360405f2001600260ff19825416179055604051908152a1005b60405162461bcd60e51b8152602060048201526015602482015274426f6f6b696e67206e6f7420617661696c61626c6560581b6044820152606490fd5b60405162461bcd60e51b815260206004820152601060248201526f27b7363c903437ba32b61037bbb732b960811b6044820152606490fd5b3461008f57602036600319011261008f576004355f52600260205260405f2060018060a01b0381541660018201549160ff6003600283015492015416926040519283526020830152604082015260048210156101c8576080916060820152f35b3461008f57602036600319011261008f5760043590815f52600260205260405f209060018060a01b0382541633148015610572575b1561053f57506003810160ff81541660048110156101c85760010361050a57805460ff191660031790556002810180545f91829055915490918291829182916001600160a01b03165af13d15610505573d67ffffffffffffffff81116101dc5760405190601f8101601f19908116603f0116820167ffffffffffffffff8111838210176101dc5760405281525f60203d92013e5b156104d05760207ff774c001cb52a3566b767ed6e37c92706acb2b80a3ff6049e2849cd62725d08591604051908152a1005b60405162461bcd60e51b815260206004820152600d60248201526c1499599d5b990819985a5b1959609a1b6044820152606490fd5b61049e565b60405162461bcd60e51b815260206004820152600d60248201526c10d85b9b9bdd0818d85b98d95b609a1b6044820152606490fd5b62461bcd60e51b815260206004820152600e60248201526d139bdd08185d5d1a1bdc9a5e995960921b6044820152606490fd5b505f546001600160a01b0316331461040a56fea2646970667358221220976849ebc286ca0a988fa15479a20ef81b4ab63b9ac26d7f8eeeb551accc2adc64736f6c63430008260033";
        public HotelBookingDeploymentBase() : base(BYTECODE) { }
        public HotelBookingDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BookRoomFunction : BookRoomFunctionBase { }

    [Function("bookRoom")]
    public class BookRoomFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "roomNumber", 1)]
        public virtual BigInteger RoomNumber { get; set; }
    }

    public partial class BookingCountFunction : BookingCountFunctionBase { }

    [Function("bookingCount", "uint256")]
    public class BookingCountFunctionBase : FunctionMessage
    {

    }

    public partial class BookingsFunction : BookingsFunctionBase { }

    [Function("bookings", typeof(BookingsOutputDTO))]
    public class BookingsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CancelBookingFunction : CancelBookingFunctionBase { }

    [Function("cancelBooking")]
    public class CancelBookingFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "bookingId", 1)]
        public virtual BigInteger BookingId { get; set; }
    }

    public partial class ConfirmBookingFunction : ConfirmBookingFunctionBase { }

    [Function("confirmBooking")]
    public class ConfirmBookingFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "bookingId", 1)]
        public virtual BigInteger BookingId { get; set; }
    }

    public partial class HotelOwnerFunction : HotelOwnerFunctionBase { }

    [Function("hotelOwner", "address")]
    public class HotelOwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RoomPriceFunction : RoomPriceFunctionBase { }

    [Function("roomPrice", "uint256")]
    public class RoomPriceFunctionBase : FunctionMessage
    {

    }



    public partial class BookingCountOutputDTO : BookingCountOutputDTOBase { }

    [FunctionOutput]
    public class BookingCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BookingsOutputDTO : BookingsOutputDTOBase { }

    [FunctionOutput]
    public class BookingsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "guest", 1)]
        public virtual string Guest { get; set; }
        [Parameter("uint256", "roomNumber", 2)]
        public virtual BigInteger RoomNumber { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint8", "status", 4)]
        public virtual byte Status { get; set; }
    }





    public partial class HotelOwnerOutputDTO : HotelOwnerOutputDTOBase { }

    [FunctionOutput]
    public class HotelOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RoomPriceOutputDTO : RoomPriceOutputDTOBase { }

    [FunctionOutput]
    public class RoomPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BookingCancelledEventDTO : BookingCancelledEventDTOBase { }

    [Event("BookingCancelled")]
    public class BookingCancelledEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "bookingId", 1, false )]
        public virtual BigInteger BookingId { get; set; }
    }

    public partial class BookingConfirmedEventDTO : BookingConfirmedEventDTOBase { }

    [Event("BookingConfirmed")]
    public class BookingConfirmedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "bookingId", 1, false )]
        public virtual BigInteger BookingId { get; set; }
    }

    public partial class RoomBookedEventDTO : RoomBookedEventDTOBase { }

    [Event("RoomBooked")]
    public class RoomBookedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "bookingId", 1, false )]
        public virtual BigInteger BookingId { get; set; }
        [Parameter("address", "guest", 2, false )]
        public virtual string Guest { get; set; }
        [Parameter("uint256", "roomNumber", 3, false )]
        public virtual BigInteger RoomNumber { get; set; }
    }
}
