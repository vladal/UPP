
using System;
using System.Data.SqlClient;
using V82;
using V82.СправочникиСсылка;
using V82.СправочникиОбъект;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.СправочникиОбъект
{
	public partial class СпецификацииНоменклатуры:СправочникОбъект
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
		///<summary>
		///(Общ)
		///</summary>
		public V82.Перечисления/*Ссылка*/.СостоянияОбъектов Состояние;
		///<summary>
		///(Общ)
		///</summary>
		public DateTime ДатаУтверждения;//Дата утверждения
		public V82.Перечисления/*Ссылка*/.ВидыСпецификаций ВидСпецификации;//Вид спецификации
		public bool Активная;
		public string/*(5)*/ КодВерсии;//Код версии
		///<summary>
		///(Общ) Любая дополнительная информация
		///</summary>
		public string/*(0)*/ Комментарий;
		///<summary>
		///(Общ)
		///</summary>
		public V82.СправочникиСсылка.Пользователи Ответственный;
		public bool ИспользоватьВозвратныеОтходы;//Использовать возвратные отходы
		public bool ИспользоватьПараметрыВыпускаПродукции;//Использовать параметры выпуска продукции
		public bool ИспользоватьДокументацию;//Использовать документацию
		public bool ИспользоватьВидНорматива;//Использовать вид норматива
		public bool ИспользоватьВидВоспроизводства;//Использовать вид воспроизводства
		public bool ИспользоватьУказаниеНорматива;//Использовать указание норматива
		public bool ИспользоватьФормулы;//Использовать формулы
		public bool ИспользоватьУправлениеСписанием;//Использовать управление списанием
		public V82.СправочникиСсылка.НазначенияИспользованияСпецификаций Назначение;
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
						Insert Into _Reference239(
						_IDRRef
						/*,_Version*/
						,_Marked
						,_IsMetadata
						,_ParentIDRRef
						,_Folder
						,_Code
						,_Description
						,_Fld3578RRef
						,_Fld3579
						,_Fld3580RRef
						,_Fld3581
						,_Fld3582
						,_Fld3583
						,_Fld3584RRef
						,_Fld3585
						,_Fld3586
						,_Fld3587
						,_Fld3588
						,_Fld3589
						,_Fld3590
						,_Fld3591
						,_Fld3592
						,_Fld3593RRef)
						Values(
						@Ссылка
						/*,@Версия*/
						,@ПометкаУдаления
						,@Предопределенный
						,@Родитель
						,@ЭтоГруппа
						,@Код
						,@Наименование
						,@Состояние
						,@ДатаУтверждения
						,@ВидСпецификации
						,@Активная
						,@КодВерсии
						,@Комментарий
						,@Ответственный
						,@ИспользоватьВозвратныеОтходы
						,@ИспользоватьПараметрыВыпускаПродукции
						,@ИспользоватьДокументацию
						,@ИспользоватьВидНорматива
						,@ИспользоватьВидВоспроизводства
						,@ИспользоватьУказаниеНорматива
						,@ИспользоватьФормулы
						,@ИспользоватьУправлениеСписанием
						,@Назначение)";
					}
					else
					{
						Команда.CommandText = @"
						Update _Reference239
						Set
						/*_IDRRef	= @Ссылка*/
						/*,_Version	= @Версия*/
						_Marked	= @ПометкаУдаления
						,_IsMetadata	= @Предопределенный
						,_ParentIDRRef	= @Родитель
						,_Folder	= @ЭтоГруппа
						,_Code	= @Код
						,_Description	= @Наименование
						,_Fld3578RRef	= @Состояние
						,_Fld3579	= @ДатаУтверждения
						,_Fld3580RRef	= @ВидСпецификации
						,_Fld3581	= @Активная
						,_Fld3582	= @КодВерсии
						,_Fld3583	= @Комментарий
						,_Fld3584RRef	= @Ответственный
						,_Fld3585	= @ИспользоватьВозвратныеОтходы
						,_Fld3586	= @ИспользоватьПараметрыВыпускаПродукции
						,_Fld3587	= @ИспользоватьДокументацию
						,_Fld3588	= @ИспользоватьВидНорматива
						,_Fld3589	= @ИспользоватьВидВоспроизводства
						,_Fld3590	= @ИспользоватьУказаниеНорматива
						,_Fld3591	= @ИспользоватьФормулы
						,_Fld3592	= @ИспользоватьУправлениеСписанием
						,_Fld3593RRef	= @Назначение
						Where _IDRRef = @Ссылка";
					}
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					/*Команда.Parameters.AddWithValue("Версия", Версия);*/
					Команда.Parameters.AddWithValue("ПометкаУдаления", ПометкаУдаления);
					Команда.Parameters.AddWithValue("Предопределенный", Предопределенный);
					Команда.Parameters.AddWithValue("Родитель", Родитель);
					Команда.Parameters.AddWithValue("ЭтоГруппа", ЭтоГруппа?new byte[]{0}:new byte[]{1});
					Команда.Parameters.AddWithValue("Код", Код);
					Команда.Parameters.AddWithValue("Наименование", Наименование);
					Команда.Parameters.AddWithValue("Состояние", Состояние.Ключ());
					Команда.Parameters.AddWithValue("ДатаУтверждения", ДатаУтверждения);
					Команда.Parameters.AddWithValue("ВидСпецификации", ВидСпецификации.Ключ());
					Команда.Parameters.AddWithValue("Активная", Активная);
					Команда.Parameters.AddWithValue("КодВерсии", КодВерсии);
					Команда.Parameters.AddWithValue("Комментарий", Комментарий);
					Команда.Parameters.AddWithValue("Ответственный", Ответственный.Ссылка);
					Команда.Parameters.AddWithValue("ИспользоватьВозвратныеОтходы", ИспользоватьВозвратныеОтходы);
					Команда.Parameters.AddWithValue("ИспользоватьПараметрыВыпускаПродукции", ИспользоватьПараметрыВыпускаПродукции);
					Команда.Parameters.AddWithValue("ИспользоватьДокументацию", ИспользоватьДокументацию);
					Команда.Parameters.AddWithValue("ИспользоватьВидНорматива", ИспользоватьВидНорматива);
					Команда.Parameters.AddWithValue("ИспользоватьВидВоспроизводства", ИспользоватьВидВоспроизводства);
					Команда.Parameters.AddWithValue("ИспользоватьУказаниеНорматива", ИспользоватьУказаниеНорматива);
					Команда.Parameters.AddWithValue("ИспользоватьФормулы", ИспользоватьФормулы);
					Команда.Parameters.AddWithValue("ИспользоватьУправлениеСписанием", ИспользоватьУправлениеСписанием);
					Команда.Parameters.AddWithValue("Назначение", Назначение.Ссылка);
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
					Команда.CommandText = @"Delete _Reference239
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", Ссылка.ToByteArray());
					Команда.ExecuteNonQuery();
				}
			}
		}
		/*МодульОбъекта*/

		public object ПечатьСпецификацииГост(/**/)
		{
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	СпецификацииНоменклатуры.Ссылка.Код 		 			КАК Код,
	|	СпецификацииНоменклатуры.Ссылка.Наименование 			КАК Обозначение,
	|	ВЫРАЗИТЬ(СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное КАК Строка(1000)) КАК Наименование,
	|	СпецификацииНоменклатуры.ХарактеристикаНоменклатуры 	КАК Характеристика,
	|	NULL 													КАК Серия
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.ВыходныеИзделия КАК СпецификацииНоменклатуры
	|ГДЕ
	|	СпецификацииНоменклатуры.Ссылка = &ТекущийЭлемент
	|";*/
			//Шапка = Запрос.Выполнить().Выбрать();
			//Шапка.Следующий();
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			//МассивВидыНормативов = Новый Массив;
			//МассивВидыНормативов.Добавить(Перечисления.ВидыНормативовНоменклатуры.Номенклатура);
			//МассивВидыНормативов.Добавить(Перечисления.ВидыНормативовНоменклатуры.Узел);
			//Запрос.УстановитьПараметр("ВидыНормативов", МассивВидыНормативов);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	ПозицияПоСпецификации			КАК Позиция,
	|	Номенклатура,
	|	ХарактеристикаНоменклатуры 		КАК Характеристика,
	|	NULL							КАК Серия,
	|	Номенклатура.ВидНоменклатуры.Наименование КАК ВидНоменклатуры,
	|	ВЫБОР КОГДА Номенклатура.НаименованиеПолное ЕСТЬ NULL ТОГДА
	|		Номенклатура.Наименование
	|	ИНАЧЕ
	|		ВЫРАЗИТЬ(Номенклатура.НаименованиеПолное КАК Строка(1000))
	|	КОНЕЦ КАК Наименование,
	|	Номенклатура.Код     			КАК Обозначение,
	|	Количество						КАК Количество,
	|	ЕдиницаИзмерения.Представление 	КАК ЕдиницаИзмерения
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.ИсходныеКомплектующие КАК СпецификацияНоменклатуры
	|ГДЕ
	|	СпецификацияНоменклатуры.Ссылка = &ТекущийЭлемент
	|	И СпецификацияНоменклатуры.ВидНорматива В (&ВидыНормативов)
	|
	|ОБЪЕДИНИТЬ ВСЕ
	|	
	|ВЫБРАТЬ
	|	НомерСтроки КАК Позиция,
	|	Наименование КАК Номенклатура,
	|	Неопределено КАК Характеристика,
	|	Неопределено КАК Серия,
	|	""Документация"" КАК ВидНоменклатуры,
	|	Наименование,
	|	Обозначение,
	|	0 КАК Количество,
	|	Неопределено КАК ЕдиницаИзмерения
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.Документация КАК Документация
	|ГДЕ
	|	Документация.Ссылка = &ТекущийЭлемент
	|
	|УПОРЯДОЧИТЬ ПО
	|	ВидНоменклатуры Возр, 
	|	Позиция
	|	
	|";*/
			//ЗапросМатериалы = Запрос.Выполнить().Выгрузить();
			//ТабДокумент = Новый ТабличныйДокумент;
			//ТабДокумент.ИмяПараметровПечати = "ПАРАМЕТРЫ_ПЕЧАТИ_СпецификацияГост";
			/*// Зададим параметры макета.
*/
			//ТабДокумент.ОбластьПечати = ТабДокумент.Область(2,2,ТабДокумент.ВысотаТаблицы, 8);
			//ТабДокумент.ПолеСверху              = 5;
			//ТабДокумент.ПолеСлева               = 15;
			//ТабДокумент.ПолеСнизу               = 0;
			//ТабДокумент.ПолеСправа              = 0;
			//ТабДокумент.РазмерКолонтитулаСверху = 0;
			//ТабДокумент.РазмерКолонтитулаСнизу  = 0;
			//ТабДокумент.ОриентацияСтраницы      = ОриентацияСтраницы.Портрет;
			//Макет = ПолучитьМакет("СпецификацияГост");
			//НомерСтраницы = 1;
			/*// Выводим шапку спецификации.
*/
			//ЗаголовокТаблицы = Макет.ПолучитьОбласть("ШапкаТаблицы");
			//ТабДокумент.Вывести(ЗаголовокТаблицы);
			//ОбластьОсновнойНадписи = Макет.ПолучитьОбласть("ОсновнаяНадпись");
			//ОбластьОсновнойНадписи.Параметры.Наименование = "" + СокрЛП(Шапка.Наименование) + ФормированиеПечатныхФорм.ПредставлениеСерий(Шапка);
			//ОбластьДанных = Макет.ПолучитьОбласть("Строка");
			//МассивТаблиц = Новый Массив;
			//МассивТаблиц.Добавить(ОбластьОсновнойНадписи);
			//МассивТаблиц.Добавить(ОбластьДанных);
			//МассивТаблиц.Добавить(ОбластьДанных);
			//ТекВидНоменклатуры = "";
			while(true/*ФормированиеПечатныхФорм.ПроверитьВыводТабличногоДокумента(ТабДокумент, МассивТаблиц, Ложь)*/)
			{
				//ОбластьДанных = Макет.ПолучитьОбласть("Строка");
				//ОбластьДанных.ТекущаяОбласть.ВысотаСтроки = 24;
				//ТабДокумент.Вывести(ОбластьДанных);
			}
			if(true/*НомерСтраницы = 1*/)
			{
				//ОбластьОсновнойНадписи = Макет.ПолучитьОбласть("ОсновнаяНадпись");
				//ОбластьОсновнойНадписи.Параметры.Наименование = "" + Шапка.Наименование + ФормированиеПечатныхФорм.ПредставлениеСерий(Шапка);
			}
			//ОбластьОсновнойНадписи.Параметры.НомерСтраницы = НомерСтраницы;
			//ОбластьОсновнойНадписи.Параметры.Обозначение = "" + Шапка.Код + " " + Шапка.Обозначение;
			//ТабДокумент.Вывести(ОбластьОсновнойНадписи);
			//ТабДокумент.Область("ВсегоСтраниц").Текст = НомерСтраницы;
			return null;
		}
		// ПечатьСпецификацииГост()
		// Процедура выводит в табличный документ раздел спецификации.
		//

		public void ВывестиРазделСпецификации(/*ТабДокумент, Макет, ВыборкаСтрок, ТекстЗаголовка*/)
		{
			if(true/*ВыборкаСтрок.Количество() = 0*/)
			{
			}
			//ДопКолонка = Константы.ДополнительнаяКолонкаПечатныхФормДокументов.Получить();
			//Колонка = "";
			if(true/*ДопКолонка = Перечисления.ДополнительнаяКолонкаПечатныхФормДокументов.Артикул*/)
			{
				//ВыводитьКоды = Истина;
				//Колонка = "Артикул";
			}
			//ОбластьМакета = Макет.ПолучитьОбласть("ШапкаЗаголовок");
			//ОбластьМакета.Параметры.ТекстЗаголовка = ТекстЗаголовка;
			//ТабДокумент.Вывести(ОбластьМакета);
			//Область = Макет.ПолучитьОбласть(?(ВыводитьКоды, "ШапкаСКодом", "Шапка"));
			if(true/*ВыводитьКоды*/)
			{
				//Область.Параметры.ИмяКолонкиКодов = Колонка;
			}
			//ТабДокумент.Вывести(Область);
			//Область = Макет.ПолучитьОбласть(?(ВыводитьКоды, "СтрокаСКодом", "Строка"));
			//Ном = 0;
			/*// Выборка выходных изделий.
*/
			while(true/*ВыборкаСтрок.Следующий()*/)
			{
				if(true/*НЕ ЗначениеЗаполнено(ВыборкаСтрок.Номенклатура)*/)
				{
					//ОбщегоНазначения.Сообщение("В одной из строк не заполнено значение номенклатуры - строка при печати пропущена.", СтатусСообщения.Важное);
				}
				//Ном = Ном + 1;
				//Область.Параметры.Заполнить(ВыборкаСтрок);
				//Область.Параметры.НомерСтроки = Ном;
				if(true/*Колонка = "Артикул"*/)
				{
					//Область.Параметры.Артикул = ВыборкаСтрок.Артикул;
				}
				//Область.Параметры.Номенклатура = СокрЛП(ВыборкаСтрок.Наименование) + ФормированиеПечатныхФорм.ПредставлениеСерий(ВыборкаСтрок);
				//Область.Параметры.НоменклатураРасшифровка = ВыборкаСтрок.Номенклатура;
				//ТабДокумент.Вывести(Область);
			}
			/*// Вывести подвал
*/
			//Область = Макет.ПолучитьОбласть("Подвал");
			//ТабДокумент.Вывести(Область);
		}
		// ВывестиРазделСпецификации()
		// Функция формирует табличный документ с печатной формой спецификации
		// по ГОСТ 2.106-96.
		//
		// Возвращаемое значение:
		//  Табличный документ - печатная форма спецификации
		//

		public object ПечатьСпецификации(/**/)
		{
			//ТабДокумент = Новый ТабличныйДокумент;
			//ТабДокумент.ИмяПараметровПечати = "ПАРАМЕТРЫ_ПЕЧАТИ_Спецификация";
			//Макет = ПолучитьМакет("Спецификация");
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	СпецификацииНоменклатуры.Код 		 				КАК Код,
	|	СпецификацииНоменклатуры.Наименование 				КАК Наименование,
	|	СпецификацииНоменклатуры.Ответственный.Наименование КАК ОтветственныйНаименование
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры КАК СпецификацииНоменклатуры
	|ГДЕ
	|	СпецификацииНоменклатуры.Ссылка = &ТекущийЭлемент
	|";*/
			//Шапка = Запрос.Выполнить().Выбрать();
			//Шапка.Следующий();
			/*// Выводим шапку накладной
*/
			//ОбластьМакета = Макет.ПолучитьОбласть("Заголовок");
			//ОбластьМакета.Параметры.ТекстЗаголовка = "Спецификация номенклатуры: " + Шапка.Наименование;
			//ТабДокумент.Вывести(ОбластьМакета);
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	СпецификацииНоменклатуры.Номенклатура.Код 		 		КАК Код,
	|	СпецификацииНоменклатуры.Номенклатура.Артикул 		 	КАК Артикул,
	|	СпецификацииНоменклатуры.Номенклатура 					КАК Номенклатура,
	|	ВЫРАЗИТЬ(СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное КАК Строка(1000)) КАК Наименование,
	|	СпецификацииНоменклатуры.ХарактеристикаНоменклатуры 	КАК Характеристика,
	|	NULL 													КАК Серия,
	|	СпецификацииНоменклатуры.Количество 					КАК Количество,
	|	СпецификацииНоменклатуры.ЕдиницаИзмерения 				КАК ЕдиницаИзмерения
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.ВыходныеИзделия КАК СпецификацииНоменклатуры
	|ГДЕ
	|	СпецификацииНоменклатуры.Ссылка = &ТекущийЭлемент
	|";*/
			//ВыборкаСтрок = Запрос.Выполнить().Выбрать();
			//ТекстЗаголовка = "Выходные изделия";
			//ВывестиРазделСпецификации(ТабДокумент, Макет, ВыборкаСтрок, ТекстЗаголовка);
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	СпецификацииНоменклатуры.Номенклатура.Код 		 		КАК Код,
	|	СпецификацииНоменклатуры.Номенклатура.Артикул 		 	КАК Артикул,
	|	СпецификацииНоменклатуры.Номенклатура 					КАК Номенклатура,
	|	ВЫБОР КОГДА СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное ЕСТЬ NULL ТОГДА
	|		СпецификацииНоменклатуры.Номенклатура
	|	ИНАЧЕ
	|		ВЫРАЗИТЬ(СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное КАК Строка(1000))
	|	КОНЕЦ КАК Наименование,
	|	СпецификацииНоменклатуры.ХарактеристикаНоменклатуры 	КАК Характеристика,
	|	NULL 													КАК Серия,
	|	СпецификацииНоменклатуры.Количество 					КАК Количество,
	|	СпецификацииНоменклатуры.ЕдиницаИзмерения 				КАК ЕдиницаИзмерения
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.ИсходныеКомплектующие КАК СпецификацииНоменклатуры
	|ГДЕ
	|	СпецификацииНоменклатуры.Ссылка = &ТекущийЭлемент
	|";*/
			//ВыборкаСтрок = Запрос.Выполнить().Выбрать();
			//ТекстЗаголовка = "Исходные комплектующие";
			//ВывестиРазделСпецификации(ТабДокумент, Макет, ВыборкаСтрок, ТекстЗаголовка);
			//Запрос = Новый Запрос;
			//Запрос.УстановитьПараметр("ТекущийЭлемент", ЭтотОбъект.Ссылка);
			/*Запрос.Текст = "
	|ВЫБРАТЬ
	|	СпецификацииНоменклатуры.Номенклатура.Код 		 		КАК Код,
	|	СпецификацииНоменклатуры.Номенклатура.Артикул 		 	КАК Артикул,
	|	СпецификацииНоменклатуры.Номенклатура 					КАК Номенклатура,
	|	ВЫБОР КОГДА СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное ЕСТЬ NULL ТОГДА
	|		СпецификацииНоменклатуры.Номенклатура
	|	ИНАЧЕ
	|		ВЫРАЗИТЬ(СпецификацииНоменклатуры.Номенклатура.НаименованиеПолное КАК Строка(1000))
	|	КОНЕЦ КАК Наименование,
	|	СпецификацииНоменклатуры.ХарактеристикаНоменклатуры 	КАК Характеристика,
	|	NULL 													КАК Серия,
	|	СпецификацииНоменклатуры.Количество 					КАК Количество,
	|	СпецификацииНоменклатуры.ЕдиницаИзмерения 				КАК ЕдиницаИзмерения
	|ИЗ
	|	Справочник.СпецификацииНоменклатуры.ВозвратныеОтходы КАК СпецификацииНоменклатуры
	|ГДЕ
	|	СпецификацииНоменклатуры.Ссылка = &ТекущийЭлемент
	|";*/
			//ВыборкаСтрок = Запрос.Выполнить().Выбрать();
			//ТекстЗаголовка = "Возвратные отходы";
			//ВывестиРазделСпецификации(ТабДокумент, Макет, ВыборкаСтрок, ТекстЗаголовка);
			/*// Вывести подписи
*/
			//ОбластьМакета = Макет.ПолучитьОбласть("Подписи");
			//ОбластьМакета.Параметры.Заполнить(Шапка);
			//ТабДокумент.Вывести(ОбластьМакета);
			/*// Зададим параметры макета.
*/
			//ТабДокумент.ОбластьПечати = ТабДокумент.Область(2,2,ТабДокумент.ВысотаТаблицы, ТабДокумент.ШиринаТаблицы);
			//ТабДокумент.ПолеСверху              = 5;
			//ТабДокумент.ПолеСлева               = 15;
			//ТабДокумент.ПолеСнизу               = 0;
			//ТабДокумент.ПолеСправа              = 0;
			//ТабДокумент.РазмерКолонтитулаСверху = 0;
			//ТабДокумент.РазмерКолонтитулаСнизу  = 0;
			//ТабДокумент.ОриентацияСтраницы      = ОриентацияСтраницы.Портрет;
			return null;
		}
		// ПечатьСпецификации()
		// Процедура осуществляет печать справочника. Можно направить печать на
		// экран или принтер, а также распечатать необходимое количество копий.
		//
		//  Название макета печати передается в качестве параметра,
		// по переданному названию находим имя макета в соответствии.
		//
		// Параметры:
		//  НазваниеМакета - строка, название макета.
		//

		public void Печать(/*ИмяМакета, КоличествоЭкземпляров = 1, НаПринтер = Ложь*/)
		{
			/*// Получить экземпляр документа на печать
*/
			if(true/*ИмяМакета = "Спецификация"*/)
			{
				//ТабДокумент = ПечатьСпецификации();
			}
			//Заголовок = "Спецификация: " + Наименование;
			//УниверсальныеМеханизмы.НапечататьДокумент(ТабДокумент, КоличествоЭкземпляров, НаПринтер, Заголовок, Ссылка);
		}
		// Печать()
		// Возвращает доступные варианты печати документа
		//
		// Возвращаемое значение:
		//  Структура, каждая строка которой соответствует одному из вариантов печати
		//

		public object ПолучитьСтруктуруПечатныхФорм(/**/)
		{
			return null;
		}
		// ПолучитьТаблицуПечатныхФорм()
		////////////////////////////////////////////////////////////////////////////////
		// ОБРАБОТЧИКИ СОБЫТИЙ
		// Процедура - обработчик события "ОбработкаЗаполнения".
		//

		public void ОбработкаЗаполнения(/*Основание*/)
		{
			if(true/*ТипЗнч(Основание) = Тип("СправочникСсылка.Номенклатура")*/)
			{
				//НовоеИзделие = ВыходныеИзделия.Добавить();
				//НовоеИзделие.Номенклатура 		= Основание;
				//НовоеИзделие.ЕдиницаИзмерения 	= Основание.ЕдиницаХраненияОстатков;
				//НовоеИзделие.Количество 		= 1;
				//НовоеИзделие.ДоляСтоимости 		= 1;
			}
		}
		// ОбработкаЗаполнения()
		// Процедура - обработчик события "ПередЗаписью".
		//

		public void ПередЗаписью(/*Отказ*/)
		{
			if(true/*ЭтоГруппа*/)
			{
			}
			if(true/*ОбменДанными.Загрузка*/)
			{
			}
			if(true/*Не ИспользоватьВидНорматива 
	 ИЛИ Не ИспользоватьУказаниеНорматива
	 ИЛИ Не ИспользоватьУправлениеСписанием*/)
			{
			}
			//УчетСерийныхНомеров.УдалитьНеиспользуемыеСтрокиПодчиненнойТЧ(ЭтотОбъект, мПараметрыСвязиСтрокТЧ, "ИсходныеКомплектующие", "АвтоподборНоменклатуры");
			//УчетСерийныхНомеров.УдалитьНеиспользуемыеСтрокиПодчиненнойТЧ(ЭтотОбъект, мПараметрыСвязиСтрокТЧ, "ИсходныеКомплектующие", "АвтоподборХарактеристики");
			//УчетСерийныхНомеров.УдалитьНеиспользуемыеСтрокиПодчиненнойТЧ(ЭтотОбъект, мПараметрыСвязиСтрокТЧ, "ВозвратныеОтходы", "АвтоподборНоменклатурыОтходы");
			//УчетСерийныхНомеров.УдалитьНеиспользуемыеСтрокиПодчиненнойТЧ(ЭтотОбъект, мПараметрыСвязиСтрокТЧ, "ВозвратныеОтходы", "АвтоподборХарактеристикиОтходы");
		}
		// ПередЗаписью()
	}
}