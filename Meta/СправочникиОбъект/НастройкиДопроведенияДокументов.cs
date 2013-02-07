
using System;
using System.Data.SqlClient;
using V82;
using V82.СправочникиСсылка;
using V82.СправочникиОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиОбъект
{
	public partial class НастройкиДопроведенияДокументов:СправочникОбъект
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
		public string/*100*/ Наименование;
		///<summary>
		///Запускать допроведение автоматически (регламентным заданием)
		///</summary>
		public bool ФормироватьДокументыАвтоматически;//Запускать допроведение автоматически
		///<summary>
		///Уникальный идентификатор регламентного задания
		///</summary>
		public string/*(36)*/ РегламентноеЗадание;//Регламентное задание
		public string/*(0)*/ Комментарий;
		public bool ДопроводитьВсеДокументы;//Допроводить все документы
		///<summary>
		///День месяца, заканчивая которым создается задача на допроведение документов
		///</summary>
		public decimal/*(2)*/ НомерДняКонецЗапуска;//Номер дня конец запуска
		///<summary>
		///День месяца, начиная с которого создается задача на допроведение документов
		///</summary>
		public decimal/*(2)*/ НомерДняНачалоЗапуска;//Номер дня начало запуска
		public DateTime НачалоИнтервалаДопроведения;//Начало интервала допроведения
		public DateTime КонецИнтервалаДопроведения;//Конец интервала допроведения
		///<summary>
		///Количество периодов, на которые отстают обрабатываемые документы относительно текущей даты
		///</summary>
		public decimal/*(2)*/ КоличествоПериодовОтставанияКонецИнтервала;//Количество периодов отставания конец интервала
		///<summary>
		///Количество периодов, на которые отстают обрабатываемые документы относительно текущей даты
		///</summary>
		public decimal/*(2)*/ КоличествоПериодовОтставанияНачалоИнтервала;//Количество периодов отставания начало интервала
		///<summary>
		///Период, на который отстают обрабатываемые документы по сравнению с текущим периодом
		///</summary>
		public V82.Перечисления/*Ссылка*/.Периодичность ПериодичностьОтставанияКонецИнтервала;//Периодичность отставания конец интервала
		///<summary>
		///Период, на который отстают обрабатываемые документы по сравнению с текущим периодом
		///</summary>
		public V82.Перечисления/*Ссылка*/.Периодичность ПериодичностьОтставанияНачалоИнтервала;//Периодичность отставания начало интервала
		public bool РассчитыватьКонецИнтервала;//Рассчитывать конец интервала
		public bool РассчитыватьНачалоИнтервала;//Рассчитывать начало интервала
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
						Insert Into _Reference150(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_Description
						,_Fld2670
						,_Fld2671
						,_Fld2672
						,_Fld2673
						,_Fld2674
						,_Fld2675
						,_Fld2676
						,_Fld2677
						,_Fld2678
						,_Fld2679
						,_Fld2680RRef
						,_Fld2681RRef
						,_Fld2682
						,_Fld2683)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Наименование
						,@ФормироватьДокументыАвтоматически
						,@РегламентноеЗадание
						,@Комментарий
						,@ДопроводитьВсеДокументы
						,@НомерДняКонецЗапуска
						,@НомерДняНачалоЗапуска
						,@НачалоИнтервалаДопроведения
						,@КонецИнтервалаДопроведения
						,@КоличествоПериодовОтставанияКонецИнтервала
						,@КоличествоПериодовОтставанияНачалоИнтервала
						,@ПериодичностьОтставанияКонецИнтервала
						,@ПериодичностьОтставанияНачалоИнтервала
						,@РассчитыватьКонецИнтервала
						,@РассчитыватьНачалоИнтервала)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference150
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_Description	= @Наименование
						,_Fld2670	= @ФормироватьДокументыАвтоматически
						,_Fld2671	= @РегламентноеЗадание
						,_Fld2672	= @Комментарий
						,_Fld2673	= @ДопроводитьВсеДокументы
						,_Fld2674	= @НомерДняКонецЗапуска
						,_Fld2675	= @НомерДняНачалоЗапуска
						,_Fld2676	= @НачалоИнтервалаДопроведения
						,_Fld2677	= @КонецИнтервалаДопроведения
						,_Fld2678	= @КоличествоПериодовОтставанияКонецИнтервала
						,_Fld2679	= @КоличествоПериодовОтставанияНачалоИнтервала
						,_Fld2680RRef	= @ПериодичностьОтставанияКонецИнтервала
						,_Fld2681RRef	= @ПериодичностьОтставанияНачалоИнтервала
						,_Fld2682	= @РассчитыватьКонецИнтервала
						,_Fld2683	= @РассчитыватьНачалоИнтервала
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("ФормироватьДокументыАвтоматически", ФормироватьДокументыАвтоматически);
					Команда.Parameters.AddWithValue("РегламентноеЗадание", РегламентноеЗадание);
					Команда.Parameters.AddWithValue("Комментарий", Комментарий);
					Команда.Parameters.AddWithValue("ДопроводитьВсеДокументы", ДопроводитьВсеДокументы);
					Команда.Parameters.AddWithValue("НомерДняКонецЗапуска", НомерДняКонецЗапуска);
					Команда.Parameters.AddWithValue("НомерДняНачалоЗапуска", НомерДняНачалоЗапуска);
					Команда.Parameters.AddWithValue("НачалоИнтервалаДопроведения", НачалоИнтервалаДопроведения);
					Команда.Parameters.AddWithValue("КонецИнтервалаДопроведения", КонецИнтервалаДопроведения);
					Команда.Parameters.AddWithValue("КоличествоПериодовОтставанияКонецИнтервала", КоличествоПериодовОтставанияКонецИнтервала);
					Команда.Parameters.AddWithValue("КоличествоПериодовОтставанияНачалоИнтервала", КоличествоПериодовОтставанияНачалоИнтервала);
					Команда.Parameters.AddWithValue("ПериодичностьОтставанияКонецИнтервала", ПериодичностьОтставанияКонецИнтервала.Ключ());
					Команда.Parameters.AddWithValue("ПериодичностьОтставанияНачалоИнтервала", ПериодичностьОтставанияНачалоИнтервала.Ключ());
					Команда.Parameters.AddWithValue("РассчитыватьКонецИнтервала", РассчитыватьКонецИнтервала);
					Команда.Parameters.AddWithValue("РассчитыватьНачалоИнтервала", РассчитыватьНачалоИнтервала);
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
					Команда.CommandText = @"Delete _Reference150
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/
		// Подготавливает заголовок сообщений об ошибках при записи
		//
		// Возвращаемое значение
		//  Строка, заголовок сообщений

		public object ЗаголовокПриЗаписи(/**/)
		{
			return null;
		}
		// Выполняет проверку заполненности реквизитов.
		//
		// Параметры
		//	Заголовок - заголовок сообщения об ошибке
		//
		// Возвращаемое значение
		//	Истина  - все проверяемые реквизиты заполнены
		//	Ложь	- не все проверяемые реквизиты заполнены

		public object РеквизитыЗаполнены(/*Знач Заголовок*/)
		{
			//Отказ = НЕ ЗначениеЗаполнено(Наименование);
			return null;
		}
		// Возвращает имя объекта метаданных для создания регл. задания
		//
		// Возвращаемое значение
		//	Строка  - имя объекта метаданных

		public object ИмяРегламентногоЗадания(/**/)
		{
			return null;
		}

		public void ПередЗаписью(/*Отказ*/)
		{
			if(true/*НЕ ЗначениеЗаполнено(Наименование)*/)
			{
				//ОбщегоНазначения.СообщитьОбОшибке("Не указано наименование", Отказ, ЗаголовокПриЗаписи());
			}
		}
	}
}