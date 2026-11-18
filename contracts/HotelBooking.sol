
 // SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

contract HotelBooking {
    address public hotelOwner;
    uint256 public roomPrice = 1 ether;

    enum Status {
        None,
        Booked,
        Confirmed,
        Cancelled
    }

    struct Booking {
        address guest;
        uint256 roomNumber;
        uint256 amount;
        Status status;
    }

    mapping(uint256 => Booking) public bookings;
    uint256 public bookingCount;

    event RoomBooked(
        uint256 bookingId,
        address guest,
        uint256 roomNumber
    );

    event BookingConfirmed(uint256 bookingId);
    event BookingCancelled(uint256 bookingId);

    constructor() {
        hotelOwner = msg.sender;
    }

    modifier onlyOwner() {
        require(msg.sender == hotelOwner, "Only hotel owner");
        _;
    }

    function bookRoom(uint256 roomNumber) public payable {
        require(roomNumber > 0, "Invalid room");
        require(
    msg.value == roomPrice,
    "Incorrect payment: send exactly 1 ETH"
);

        bookingCount++;

        bookings[bookingCount] = Booking(
            msg.sender,
            roomNumber,
            msg.value,
            Status.Booked
        );

        emit RoomBooked(
            bookingCount,
            msg.sender,
            roomNumber
        );
    }

    function confirmBooking(uint256 bookingId)
        public
        onlyOwner
    {
        require(
            bookings[bookingId].status == Status.Booked,
            "Booking not available"
        );

        bookings[bookingId].status = Status.Confirmed;

        emit BookingConfirmed(bookingId);
    }

    function cancelBooking(uint256 bookingId) public {
        Booking storage booking = bookings[bookingId];

        require(
            msg.sender == booking.guest ||
            msg.sender == hotelOwner,
            "Not authorized"
        );

        require(
            booking.status == Status.Booked,
            "Cannot cancel"
        );

        booking.status = Status.Cancelled;

        uint256 refund = booking.amount;
        booking.amount = 0;

        (bool success, ) = payable(booking.guest).call{
            value: refund
        }("");

        require(success, "Refund failed");

        emit BookingCancelled(bookingId);
    }
}
