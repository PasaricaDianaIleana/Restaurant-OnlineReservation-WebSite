﻿using RestaurantDataAccess.Models;
using RestaurantDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDataAccess.DataRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }
        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation != null)
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return reservation;
            }

            return null;
        }

        public void DeleteReservation(int id)
        {
            var data = GetReservationById(id);
            if (data != null)
            {
                _context.Reservations.Remove(data);
                _context.SaveChanges();
            }
        }

        public Reservation EditReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(x => x.ReservationId == id);
        }

        public List<Reservation> GetReservationsByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}