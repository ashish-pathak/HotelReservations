using System;

namespace HotelReservations
{
    class Program
    {
        /// <summary>
        /// Validates reservation request
        /// </summary>
        /// <param name="roomCount">Number of rooms</param>
        /// <param name="startDay">Start day</param>
        /// <param name="endDay">End day</param>
        /// <returns>Boolean value indicating whether request is valid</returns>
        private static bool IsRequestValid(int roomCount, int startDay, int endDay)
        {
            // validating the start day and end day of the request
            return startDay >= 0 && endDay >= startDay && endDay <= 364;
        }

        /// <summary>
        /// Process the reservation request 
        /// </summary>
        /// <param name="startDay">Start day</param>
        /// <param name="endDay">End day</param>
        /// <param name="roomCount">Number of rooms</param>
        /// <param name="reservationData">Reservation data containing number of occupied rooms on each day</param>
        /// <returns>Boolean variable indicating whether room is available</returns>
        public static bool IsRoomAvailable(int startDay, int endDay, int roomCount, int[] reservationData)
        {
            // if the request is invalid, decline the reservation request
            if (!IsRequestValid(roomCount, startDay, endDay))
            {
                return false;
            }

            // check if the room is available on each day from start to end
            for (int i = startDay; i <= endDay; i++)
            {
                if (reservationData[i] >= roomCount)
                    return false;
            }

            // if we reach so far, rooms are available
            // increment the number of occupied rooms in reservation data
            for (int i = startDay; i <= endDay; i++)
            {
                reservationData[i]++;
            }

            // return true
            return true;
        }

        /// <summary>
        /// Displays the result
        /// </summary>
        /// <param name="startDays">Start day</param>
        /// <param name="endDays">End Day</param>
        /// <param name="roomCount">Number of rooms</param>
        /// <param name="reservationData">Reservation data containing number of occupied rooms on each day</param>
        static void RunTestCase(int[] startDays, int[] endDays, int roomCount, int[] reservationData)
        {
            Console.WriteLine("\t\tStart \tEnd\tResult: Accepted/Declined");
            for (int i = 0; i < startDays.Length; i++)
            {
                Console.WriteLine("Booking {0}\t{1}\t{2}\t{3}", i + 1, startDays[i], endDays[i], IsRoomAvailable(startDays[i], endDays[i], roomCount, reservationData) ? "Accepted" : "Declined");
            }
            Console.WriteLine("\n\n");
        }

        static void Main(string[] args)
        {
            // Stores the number of occupied rooms on each day, initialised to 0 and reset before executing each test case
            int[] reservationData = new int[365];

            //Test Case 1a
            int[] startDates = new int[] { -4 };
            int[] endDates = new int[] { 2 };

            RunTestCase(startDates, endDates, 1, reservationData);

            //Test Case 1b
            startDates = new int[] { 200 };
            endDates = new int[] { 400 };

            Array.Clear(reservationData, 0, 365);
            RunTestCase(startDates, endDates, 1, reservationData);

            //Test Case 2
            startDates = new int[] { 0, 7, 3, 5, 6, 0 };
            endDates = new int[] { 5, 13, 9, 7, 6, 4 };

            Array.Clear(reservationData, 0, 365);
            RunTestCase(startDates, endDates, 3, reservationData);

            //Test Case 3
            startDates = new int[] { 1, 2, 1, 0 };
            endDates = new int[] { 3, 5, 9, 15 };

            Array.Clear(reservationData, 0, 365);
            RunTestCase(startDates, endDates, 3, reservationData);

            //Test Cases 4
            startDates = new int[] { 1, 0, 1, 2, 4 };
            endDates = new int[] { 3, 15, 9, 5, 9 };

            Array.Clear(reservationData, 0, 365);
            RunTestCase(startDates, endDates, 3, reservationData);

            //TestCase 5
            startDates = new int[] { 1, 0, 2, 5, 4, 10, 6, 8, 8 };
            endDates = new int[] { 3, 4, 3, 5, 10, 10, 7, 10, 9 };

            Array.Clear(reservationData, 0, 365);
            RunTestCase(startDates, endDates, 2, reservationData);

            Console.ReadLine();
        }
    }
}
