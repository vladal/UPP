
using System;
using System.Data.SqlClient;
using V82;
using V82.СправочникиСсылка;
using V82.СправочникиОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиОбъект
{
	///<summary>
	///(Упр)
	///</summary>
	public partial class Мероприятия:СправочникОбъект
	{
		public bool _ЭтоНовый;
		public bool ЭтоНовый()
		{
			return _ЭтоНовый;
		}
		public Guid Ссылка;
		public long Версия;
		/*static хэш сумма состава и порядка реквизитов*/
		/*версия класса восстановленного из пакета*/
		public bool ПометкаУдаления;
		public bool Предопределенный;
		public Guid Владелец;
		public bool ЭтоГруппа;
		public Guid Родитель;
		public string/*9*/ Код;
		public string/*100*/ Наименование;
		public DateTime ДатаНачала;//Дата начала
		public DateTime ДатаОкончания;//Дата окончания
		public void Записать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					if(_ЭтоНовый)
					{
						Команда.CommandText = @"
						Insert Into _Reference137(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_Code
						,_Description
						,_Fld2561
						,_Fld2562)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Код
						,@Наименование
						,@ДатаНачала
						,@ДатаОкончания)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference137
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_Code	= @Код
						,_Description	= @Наименование
						,_Fld2561	= @ДатаНачала
						,_Fld2562	= @ДатаОкончания
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Код", Код);
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("ДатаНачала", ДатаНачала);
					Команда.Parameters.AddWithValue("ДатаОкончания", ДатаОкончания);
					Команда.ExecuteNonQuery();
				}
			}
		}
		public void Удалить()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Delete _Reference137
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/

		public void ВывестиСтроку(/*Выборка, СтруктураПараметров, Номер*/)
		{
			//ОбластьОбщийОтступ = СтруктураПараметров.ОбщийОтступ;
			//ОбластьЗначениеГруппировки   = СтруктураПараметров.ЗначениеГруппировки;
			//ОбластьЗначенияПоказателя    = СтруктураПараметров.ЗначенияПоказателя;
			//СтруктураВыводГруппировок = СтруктураПараметров.СтруктураВыводГруппировок;
			//УровеньОкрашиваемойЗаписи = СтруктураПараметров.УровеньОкрашиваемойЗаписи;
			//УровеньЗаписи   = Выборка.Уровень();
			//ИмяГруппировки  = Выборка.Группировка();
			if(true/*НЕ ЗначениеЗаполнено(Выборка[ИмяГруппировки])*/)
			{
				if(true/*(ИмяГруппировки = "Подразделение")*/)
				{
					if(true/*Выборка.Физлицо = 0*/)
					{
						/*// эта выборка содержит те составные части мероприятия, в которых никто не участвует
*/
					}
				}
			}
			//ТабДок = СтруктураПараметров.ТабДок;
			//ЗначениеГруппировки = "";
			//ЗначениеРасшифровки = Неопределено;
			//ТипЗаписиВыборки = Выборка.ТипЗаписи();
			//МассивВыводГруппировок = Новый Массив;
			if(true/*ТипЗаписиВыборки = ТипЗаписиЗапроса.ИтогПоИерархии*/)
			{
				//ЗначениеТекущейГруппировки = "" + Выборка[ИмяГруппировки + "Представление"];
				if(true/*ПустаяСтрока(ЗначениеТекущейГруппировки)*/)
				{
					//ЗначениеТекущейГруппировки = "<...>";
				}
				//ЗначениеГруппировки = ЗначениеГруппировки + ЗначениеТекущейГруппировки;
			}
			//ТабДок.Вывести(ОбластьОбщийОтступ, УровеньЗаписи);
			//ОбластьЗначениеГруппировки.Параметры.ЗначениеГруппировки = СокрЛП(ЗначениеГруппировки);
			//ОбластьЗначениеГруппировки.Параметры.Расшифровка = ЗначениеРасшифровки;
			//ОбластьЗначениеГруппировки.Область().Отступ = УровеньЗаписи;
			//ТабДок.Присоединить(ОбластьЗначениеГруппировки);
			if(true/*ИмяГруппировки = "Физлицо"*/)
			{
			}
			//ТабДок.Область(ТабДок.ВысотаТаблицы, 2, ТабДок.ВысотаТаблицы, 2).РазмещениеТекста =  ТипРазмещенияТекстаТабличногоДокумента.Переносить;
			if(true/*ТипЗаписиВыборки = ТипЗаписиЗапроса.ИтогПоИерархии*/)
			{
				//ТабДок.Область(ТабДок.ВысотаТаблицы, 2, ТабДок.ВысотаТаблицы, 2).Шрифт = СтруктураПараметров.ШрифтГрупп;
			}
			if(true/*Номер <> 1*/)
			{
				if(true/*УровеньЗаписи = УровеньОкрашиваемойЗаписи*/)
				{
					//ТабДок.Область(ТабДок.ВысотаТаблицы, 2, ТабДок.ВысотаТаблицы, ТабДок.ШиринаТаблицы - 1).ЦветФона = ЦветаСтиля.ФонГруппировкиВерхнегоУровня;
				}
			}
		}
		// ВывестиСтроку()
		// Обход выборки из результата запроса по группировкам для вывода строк отчета
		//
		// Параметры:
		//
		//	Выборка       - выборка из результата отчета, которая обходится в процедуре,
		//	СтруктураПараметров - структура параметров, передеваемых в процедуру вывода
		//	                строки отчета,
		//	Номер         - число, номер обходимой группировки
		//

		public void ВывестиВыборку(/*Выборка, СтруктураПараметров, Номер*/)
		{
			//ОбработкаПрерыванияПользователя();
			//ВсегоГруппировок = СтруктураПараметров.ВсегоГруппировок;
			/*// Берутся группировки все подряд, 
*/
			while(true/*Выборка.Следующий()*/)
			{
				//ВывестиСтроку(Выборка, СтруктураПараметров, Номер);
				/*// Обход детальных записей здесь не нужен - это делается непосредственно при выводе строки по работнику 
*/
				/*// для последней группировки после итогов по группировке идут детальные записи
*/
				if(true/*Номер = ВсегоГруппировок - 1
			И Выборка.ТипЗаписи() =  ТипЗаписиЗапроса.ИтогПоГруппировке*/)
				{
				}
				//ВывестиВыборку(Выборка.Выбрать(ОбходРезультатаЗапроса.ПоГруппировкам), СтруктураПараметров, Номер + 1);
			}
			//;;
		}
		// ВывестиВыборку()
		////////////////////////////////////////////////////////////////////////////////
		// ЭКСПОРТНЫЕ ПРОЦЕДУРЫ И ФУНКЦИИ
		// Процедура выводит на экран печатную форму мероприятия
		//
		// Параметры:
		//  Нет
		//
		// Возвращаемое значение:
		//  Нет.
		//

		public object Печать(/*Регистратор = Неопределено*/)
		{
			//Запрос = Новый Запрос;
			//Запрос.МенеджерВременныхТаблиц = Новый МенеджерВременныхТаблиц;
			/*// Установим параметры запроса.
*/
			//Запрос.УстановитьПараметр("Ссылка",	Ссылка);
			//Запрос.УстановитьПараметр("ДатаС",	ДатаНачала);
			if(true/*ЗначениеЗаполнено(Регистратор)*/)
			{
				//Запрос.УстановитьПараметр("Документ",Регистратор);
				/*Запрос.Текст = 
		"ВЫБРАТЬ РАЗЛИЧНЫЕ
		|	УчастиеВМероприятияхРаботники.ФизЛицо КАК Физлицо
		|ПОМЕСТИТЬ ВТФизлица
		|ИЗ
		|	Документ.УчастиеВМероприятиях.Работники КАК УчастиеВМероприятияхРаботники
		|ГДЕ
		|	УчастиеВМероприятияхРаботники.Ссылка = &Документ
		|
		|ИНДЕКСИРОВАТЬ ПО
		|	Физлицо";*/
			}
			//Запрос.Выполнить();
			/*Запрос.Текст = 
	"ВЫБРАТЬ
	|	РаботникиСрезПоследних.Подразделение КАК Подразделение,
	|	РаботникиСрезПоследних.Подразделение.Представление КАК ПодразделениеПредставление,
	|	УчастникиМероприятия.ФизЛицо КАК Физлицо,
	|	ЕСТЬNULL(ФИОФизЛиц.Фамилия + "" "" + ФИОФизЛиц.Имя + "" "" + ФИОФизЛиц.Отчество, УчастникиМероприятия.ФизЛицо.Наименование) КАК ФизлицоПредставление,
	|	ПланируемаяЗанятостьФизлиц.ХарактерУчастия,
	|	СоставМероприятия.ДатаНачала КАК НачалоМероприятия,
	|	СоставМероприятия.ДатаОкончания КАК ОкончаниеМероприятия,
	|	СоставМероприятия.Ссылка КАК СоставМероприятия,
	|	СоставМероприятия.Представление КАК СоставМероприятияПредставление
	|ИЗ
	|	Справочник.СоставМероприятия КАК СоставМероприятия
	|		ЛЕВОЕ СОЕДИНЕНИЕ ВТФизлица КАК УчастникиМероприятия
	|			ЛЕВОЕ СОЕДИНЕНИЕ РегистрСведений.ФИОФизЛиц.СрезПоследних(
	|					&ДатаС,
	|					ФизЛицо В
	|						(ВЫБРАТЬ
	|							Физлица.ФизЛицо
	|						ИЗ
	|							ВТФизлица КАК Физлица)) КАК ФИОФизЛиц
	|			ПО УчастникиМероприятия.ФизЛицо = ФИОФизЛиц.ФизЛицо
	|			ЛЕВОЕ СОЕДИНЕНИЕ РегистрСведений.Работники.СрезПоследних(
	|					&ДатаС,
	|					ФизЛицо В
	|						(ВЫБРАТЬ
	|							Физлица.ФизЛицо
	|						ИЗ
	|							ВТФизлица КАК Физлица)) КАК РаботникиСрезПоследних
	|			ПО УчастникиМероприятия.ФизЛицо = РаботникиСрезПоследних.ФизЛицо
	|		ПО (ИСТИНА)
	|		ЛЕВОЕ СОЕДИНЕНИЕ РегистрСведений.СобытийныйПланЗанятостиФизлиц КАК ПланируемаяЗанятостьФизлиц
	|		ПО СоставМероприятия.Ссылка = ПланируемаяЗанятостьФизлиц.ЧастьМероприятия
	|			И УчастникиМероприятия.ФизЛицо = ПланируемаяЗанятостьФизлиц.ФизЛицо
	|ГДЕ
	|	СоставМероприятия.Владелец = &Ссылка
	|ИТОГИ ПО
	|	Подразделение ИЕРАРХИЯ,
	|	Физлицо";*/
			/*// Выполнение сформированного запроса
*/
			//Результат = Запрос.Выполнить();
			//СоответствиеФИО = Новый Соответствие;
			//Выборка = Результат.Выбрать();
			while(true/*Выборка.Следующий()*/)
			{
				//СоответствиеФИО.Вставить(Выборка.ФизЛицо, Выборка.ФизлицоПредставление);
			}
			/*;

	Макет = ПолучитьМакет("Макет");*/
			//ДокументРезультат = Новый ТабличныйДокумент;
			//ТаблицаСоставаМероприятия = Результат.Выгрузить();
			//ТаблицаСоставаМероприятия.Свернуть("СоставМероприятия,СоставМероприятияПредставление,НачалоМероприятия,ОкончаниеМероприятия",);
			//ТаблицаСоставаМероприятия.Сортировать("НачалоМероприятия");
			/*// Структура вывода группировок: ключи определяют "основные" группировки,
*/
			//ИмяГруппировки = "Подразделение";
			//СтруктураВыводГруппировок = Новый Структура;
			//СтруктураВыводГруппировок.Вставить(ИмяГруппировки,Новый  Массив);
			//СтруктураВыводГруппировок.Вставить("Физлицо",Новый  Массив);
			//МассивГруппировки    = Новый Массив;
			//МассивГруппировки.Добавить(ИмяГруппировки);
			//МассивГруппировки.Добавить("Физлицо");
			//СтруктураПараметров = Новый Структура;
			/*// Области строки отчета - табличные документы из макета отчета
*/
			//СтруктураПараметров.Вставить("ОбщийОтступ", Макет.ПолучитьОбласть("ОбщийОтступ|Строка"));
			//СтруктураПараметров.Вставить("ЗначениеГруппировки",   Макет.ПолучитьОбласть("Значение|Строка"));
			//СтруктураПараметров.Вставить("ЗначенияПоказателя",    Макет.ПолучитьОбласть("Показатель|Строка"));
			/*// Табличный документ - результат отчета
*/
			//СтруктураПараметров.Вставить("ТабДок",    ДокументРезультат);
			/*// Массив выводимых показателей отчета
*/
			//СтруктураПараметров.Вставить("МассивПоказатели", ТаблицаСоставаМероприятия.ВыгрузитьКолонку("СоставМероприятия"));
			/*// Общее количество группировок запроса, т.е. как выводимых, так и пропускаемых
*/
			//СтруктураПараметров.Вставить("ВсегоГруппировок", 			2);
			/*// Заполненная структура вывода группировок
*/
			//СтруктураПараметров.Вставить("СтруктураВыводГруппировок", 	СтруктураВыводГруппировок);
			/*// Массив всех группировок запроса, т.е. как выводимых, так и пропускаемых
*/
			//СтруктураПараметров.Вставить("МассивГруппировки", 	МассивГруппировки);
			/*// Заполненная структура "поправки" сдвига группировок вправо
*/
			/*//	СтруктураПараметров.Вставить("СтруктураСдвигУровняГруппировок", СтруктураСдвигУровняГруппировок);
*/
			/*// Наклонный шрифт для групп
*/
			//СтруктураПараметров.Вставить("ШрифтГрупп", Новый Шрифт(Макет.Область("Строка|Показатель").Шрифт,,,,Истина));
			/*// Форматная строка для вывода показателей
*/
			//СтруктураПараметров.Вставить("ФорматПоказателей", 			Новый Структура);
			/*// передадим уровень записей, которые выделять другим фоном
*/
			//СтруктураПараметров.Вставить("УровеньОкрашиваемойЗаписи", 0);
			//ДокументРезультат.Область(3,2,ДокументРезультат.ВысотаТаблицы,ДокументРезультат.ШиринаТаблицы-1).ЦветФона = ЦветаСтиля.ФонГруппировкиВерхнегоУровня;
			/*// Вывод строк отчета
*/
			//ДокументРезультат.НачатьАвтогруппировкуСтрок();
			//ВывестиВыборку(Результат.Выбрать(ОбходРезультатаЗапроса.ПоГруппировкам), СтруктураПараметров, 0);
			//ДокументРезультат.ЗакончитьАвтогруппировкуСтрок();
			//ДокументРезультат.ФиксацияСверху = 5;
			//ДокументРезультат.ФиксацияСлева = 2;
			return null;
		}
		// Печать
		// Проверяет корректность заполнения составной части мероприятия

		public object ПроверитьДатыНачалаИОконачнияСоставнойЧасти(/*ЧастьМероприятия*/)
		{
			//СтрОшибка = "";
			if(true/*НЕ ЗначениеЗаполнено(ЧастьМероприятия.ДатаНачала)*/)
			{
				//СтрОшибка = СтрОшибка + "Не указана дата начала составной части мероприятия!";
			}
			return null;
		}
	}
}