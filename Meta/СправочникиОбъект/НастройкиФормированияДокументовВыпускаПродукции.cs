
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
	///Настройки формирования документов выпуска продукции по данным подсистемы "Оперативный учет производства"
	///</summary>
	public partial class НастройкиФормированияДокументовВыпускаПродукции:СправочникОбъект
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
		public string/*70*/ Наименование;
		///<summary>
		///Дата, по которую учтены данные в сформированных документах
		///</summary>
		public DateTime ГраницаОбработки;//Граница обработки
		public V82.СправочникиСсылка.Подразделения Подразделение;
		public V82.Перечисления/*Ссылка*/.Периодичность ПериодДетализации;//Период детализации
		public string/*(50)*/ ВидРегулярногоДокумента;//Вид регулярного документа
		public V82.СправочникиСсылка.Организации Организация;
		public V82.СправочникиСсылка.ПодразделенияОрганизаций ПодразделениеОрганизации;//Подразделение организации
		public V82.СправочникиСсылка.Склады Склад;
		public bool ОтражатьВУправленческомУчете;//Отражать в управленческом учете
		public bool ОтражатьВБухгалтерскомУчете;//Отражать в бухгалтерском учете
		public bool ОтражатьВНалоговомУчете;//Отражать в налоговом учете
		public bool ОтразитьВыпуск;//Отразить выпуск
		public bool ОтразитьМатериалы;//Отразить материалы
		public bool НеОбрабатыватьПериодДоЗавершенияСмен;//Не формировать документы за период, в котором есть незавершенные смены
		///<summary>
		///Формировать документы автоматически (регламентным заданием)
		///</summary>
		public bool ФормироватьДокументыАвтоматически;//Формировать документы автоматически
		///<summary>
		///Уникальный идентификатор регламентного задания
		///</summary>
		public string/*(36)*/ РегламентноеЗадание;//Регламентное задание
		///<summary>
		///Количество дней после окончания периода, по истечении которых формируются документы
		///</summary>
		public decimal/*(2)*/ Задержка;
		public string/*(0)*/ Комментарий;
		public bool НеОбрабатыватьВсеДокументы;//Не обрабатывать все документы
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
						Insert Into _Reference158(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_ParentIDRRef
						,_Folder
						,_Description
						,_Fld2850
						,_Fld2851RRef
						,_Fld2852RRef
						,_Fld2853
						,_Fld2854RRef
						,_Fld2855RRef
						,_Fld2856RRef
						,_Fld2857
						,_Fld2858
						,_Fld2859
						,_Fld2860
						,_Fld2861
						,_Fld2862
						,_Fld2863
						,_Fld2864
						,_Fld2865
						,_Fld2866
						,_Fld2867)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Родитель
						,@ЭтоГруппа
						,@Наименование
						,@ГраницаОбработки
						,@Подразделение
						,@ПериодДетализации
						,@ВидРегулярногоДокумента
						,@Организация
						,@ПодразделениеОрганизации
						,@Склад
						,@ОтражатьВУправленческомУчете
						,@ОтражатьВБухгалтерскомУчете
						,@ОтражатьВНалоговомУчете
						,@ОтразитьВыпуск
						,@ОтразитьМатериалы
						,@НеОбрабатыватьПериодДоЗавершенияСмен
						,@ФормироватьДокументыАвтоматически
						,@РегламентноеЗадание
						,@Задержка
						,@Комментарий
						,@НеОбрабатыватьВсеДокументы)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference158
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_ParentIDRRef	= @Родитель
						,_Folder	= @ЭтоГруппа
						,_Description	= @Наименование
						,_Fld2850	= @ГраницаОбработки
						,_Fld2851RRef	= @Подразделение
						,_Fld2852RRef	= @ПериодДетализации
						,_Fld2853	= @ВидРегулярногоДокумента
						,_Fld2854RRef	= @Организация
						,_Fld2855RRef	= @ПодразделениеОрганизации
						,_Fld2856RRef	= @Склад
						,_Fld2857	= @ОтражатьВУправленческомУчете
						,_Fld2858	= @ОтражатьВБухгалтерскомУчете
						,_Fld2859	= @ОтражатьВНалоговомУчете
						,_Fld2860	= @ОтразитьВыпуск
						,_Fld2861	= @ОтразитьМатериалы
						,_Fld2862	= @НеОбрабатыватьПериодДоЗавершенияСмен
						,_Fld2863	= @ФормироватьДокументыАвтоматически
						,_Fld2864	= @РегламентноеЗадание
						,_Fld2865	= @Задержка
						,_Fld2866	= @Комментарий
						,_Fld2867	= @НеОбрабатыватьВсеДокументы
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Родитель", Родитель);
					Команда.Parameters.AddWithValue("ЭтоГруппа", ЭтоГруппа?new byte[]{0}:new byte[]{1});
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("ГраницаОбработки", ГраницаОбработки);
					Команда.Parameters.AddWithValue("Подразделение", Подразделение.Ссылка);
					Команда.Parameters.AddWithValue("ПериодДетализации", ПериодДетализации.Ключ());
					Команда.Parameters.AddWithValue("ВидРегулярногоДокумента", ВидРегулярногоДокумента);
					Команда.Parameters.AddWithValue("Организация", Организация.Ссылка);
					Команда.Parameters.AddWithValue("ПодразделениеОрганизации", ПодразделениеОрганизации.Ссылка);
					Команда.Parameters.AddWithValue("Склад", Склад.Ссылка);
					Команда.Parameters.AddWithValue("ОтражатьВУправленческомУчете", ОтражатьВУправленческомУчете);
					Команда.Parameters.AddWithValue("ОтражатьВБухгалтерскомУчете", ОтражатьВБухгалтерскомУчете);
					Команда.Parameters.AddWithValue("ОтражатьВНалоговомУчете", ОтражатьВНалоговомУчете);
					Команда.Parameters.AddWithValue("ОтразитьВыпуск", ОтразитьВыпуск);
					Команда.Parameters.AddWithValue("ОтразитьМатериалы", ОтразитьМатериалы);
					Команда.Parameters.AddWithValue("НеОбрабатыватьПериодДоЗавершенияСмен", НеОбрабатыватьПериодДоЗавершенияСмен);
					Команда.Parameters.AddWithValue("ФормироватьДокументыАвтоматически", ФормироватьДокументыАвтоматически);
					Команда.Parameters.AddWithValue("РегламентноеЗадание", РегламентноеЗадание);
					Команда.Parameters.AddWithValue("Задержка", Задержка);
					Команда.Parameters.AddWithValue("Комментарий", Комментарий);
					Команда.Parameters.AddWithValue("НеОбрабатыватьВсеДокументы", НеОбрабатыватьВсеДокументы);
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
					Команда.CommandText = @"Delete _Reference158
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/
		////////////////////////////////////////////////////////////////////////////////
		// ОБЩИЕ ПРОЦЕДУРЫ И ФУНКЦИИ
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
			if(true/*ЭтоГруппа*/)
			{
			}
			//Отказ = Ложь;
			/*// Должны быть заполнены обязательные реквизиты
*/
			//СтруктураОбязательныхПолей = Новый Структура();
			//СтруктураОбязательныхПолей.Вставить("ВидРегулярногоДокумента", "Не указан вид формируемых документов");
			//СтруктураОбязательныхПолей.Вставить("ПериодДетализации",	   "Не указан период детализации формируемых документов");
			//СтруктураОбязательныхПолей.Вставить("Организация",			   "Не указана организация, по которой формируются документы");
			//СтруктураОбязательныхПолей.Вставить("Склад",				   "Не указан склад, по которому формируются документы");
			//ЗаполнениеДокументов.ПроверитьЗаполнениеШапкиДокумента(ЭтотОбъект, СтруктураОбязательныхПолей, Отказ, Заголовок);
			/*// Документ должен принадлежать хотя бы к одному виду учета (управленческий, бухгалтерский, налоговый)
*/
			//СтруктураШапкиДокумента = Новый Структура("ОтражатьВУправленческомУчете,ОтражатьВБухгалтерскомУчете,ОтражатьВНалоговомУчете");
			//ЗаполнитьЗначенияСвойств(СтруктураШапкиДокумента, ЭтотОбъект);
			//ОбщегоНазначения.ПроверитьПринадлежностьКВидамУчета(СтруктураШапкиДокумента, Отказ, Заголовок);
			return null;
		}
		// Подготавливает заголовок сообщений об ошибках при записи
		//
		// Возвращаемое значение
		//  Строка, заголовок сообщений

		public object ЗаголовокПриЗаписи(/**/)
		{
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
		////////////////////////////////////////////////////////////////////////////////
		// ПРОЦЕДУРЫ - ОБРАБОТЧИКИ СОБЫТИЙ ОБЪЕКТА
		// Обработчик события ПередЗаписью
		// Выполняются проверки - можно записать элемент или нет.
		// При необходимости создается регламентное задание

		public void ПередЗаписью(/*Отказ*/)
		{
			if(true/*ОбменДанными.Загрузка Или ЭтоГруппа*/)
			{
			}
			/*// Не во всех документах указываются материалы
*/
			/*// Если не указываются материалы, то не имеет смысл формировать документ без выпуска
*/
			if(true/*НЕ РегламентноеФормированиеДокументов.РегламентФормированияДокументовВыпуска_ЗаполнятьМатериалы(ВидРегулярногоДокумента)*/)
			{
				//ОтразитьВыпуск    = Истина;
				//ОтразитьМатериалы = Ложь;
			}
		}
	}
}