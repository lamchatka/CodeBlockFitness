﻿using System;


namespace CodeBlockFitness.BL.Model
{
   [Serializable]
   public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        /// <summary>
        /// User constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name)) 
            {
                throw new ArgumentNullException("Имя пользователя не может быть равно null или пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть равно null или пустым", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть равно null или пустым", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
