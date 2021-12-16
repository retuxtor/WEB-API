using PresentationService.Models;
using System;
using System.Collections.Generic;

namespace PresentationService.Services.Interfaces
{
    public interface IPresentationWorker
    {
        /// <summary>
        /// Метод, который возвращает указанное кол-во полей из таблицы Presentation
        /// </summary>
        /// <param name="qauntity">Кол-во записей</param>
        IEnumerable<Presentation> GetListPresentation(int qauntity);

        /// <summary>
        /// Метод, который возвращает конкретную запись из таблицы Presentation
        /// </summary>
        /// <param name="id">Интересующий номер поля presentation</param>
        Presentation GetPresentation(int id);

        /// <summary>
        /// Метод, который получает все записи в указанном интервале 
        /// </summary>
        /// <param name="dateFrom">От</param>
        /// <param name="dateTo">До</param>
        IEnumerable<Presentation> GetPresentationInDateInterval(DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Метод, который изменяет статус событий, если они уже прошли
        /// </summary>
        bool UpdateStatus();

        /// <summary>
        /// Метод, который добавляет новую запись в presentation
        /// </summary>
        bool AddPresentation(Presentation presentation);
    }
}
