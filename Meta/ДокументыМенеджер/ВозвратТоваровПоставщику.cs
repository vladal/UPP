﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.ДокументыСсылка;
using V82.Документы;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Документы//Менеджер
{
	///<summary>
	///(Общ)
	///</summary>
	public partial class ВозвратТоваровПоставщику:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ВозвратТоваровПоставщику НайтиПоСсылке(Guid _Ссылка)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыСсылка.ВозвратТоваровПоставщику НайтиПоНомеру(string Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыВыборка.ВозвратТоваровПоставщику Выбрать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ВозвратТоваровПоставщику();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ВозвратТоваровПоставщику ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ВозвратТоваровПоставщику();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ВозвратТоваровПоставщику ВыбратьПоНомеру(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ВозвратТоваровПоставщику();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ВозвратТоваровПоставщику СтраницаПоСсылке(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ВозвратТоваровПоставщику();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ВозвратТоваровПоставщику СтраницаПоНомеру(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld3779RRef [Организация]
					,_Fld3780 [ОтражатьВУправленческомУчете]
					,_Fld3781 [ОтражатьВБухгалтерскомУчете]
					,_Fld3782 [ОтражатьВНалоговомУчете]
					,_Fld3783RRef [Подразделение]
					,_Fld3784RRef [ВидОперации]
					,_Fld3785 [Комментарий]
					,_Fld3786_TYPE [Сделка_Тип],_Fld3786_RRRef [Сделка],_Fld3786_RTRef [Сделка_Вид]
					,_Fld3787RRef [Склад]
					,_Fld3788RRef [ДоговорКонтрагента]
					,_Fld3789RRef [Контрагент]
					,_Fld3790RRef [ТипЦен]
					,_Fld3791RRef [ВалютаДокумента]
					,_Fld3792 [УчитыватьНДС]
					,_Fld3793 [СуммаВключаетНДС]
					,_Fld3794 [КурсВзаиморасчетов]
					,_Fld3795 [СуммаДокумента]
					,_Fld3796 [КратностьВзаиморасчетов]
					,_Fld3797RRef [Ответственный]
					,_Fld3798RRef [ВидПередачи]
					,_Fld3799RRef [СчетУчетаРасчетовСКонтрагентом]
					,_Fld3800RRef [СчетУчетаРасчетовПоАвансам]
					,_Fld3807RRef [СчетУчетаРасчетовПоПретензиям]
					,_Fld3801RRef [СчетУчетаРасчетовПоТаре]
					,_Fld3802 [НДСВключенВСтоимость]
					,_Fld3804RRef [БанковскийСчетОрганизации]
					,_Fld3805RRef [Грузоотправитель]
					,_Fld3806_TYPE [Проект_Тип],_Fld3806_RRRef [Проект],_Fld3806_RTRef [Проект_Вид]
					,_Fld3803RRef [Грузополучатель]
					,_Fld3808RRef [СчетУчетаДоходовБУ]
					,_Fld3809RRef [СчетУчетаРасходовБУ]
					,_Fld3810RRef [СчетУчетаДоходовНУ]
					,_Fld3811RRef [СчетУчетаРасходовНУ]
					,_Fld3812RRef [СтатьяДоходовИРасходов]
					,_Fld18951 [ПоставщикуВыставляетсяСчетФактураНаВозврат]
					From _Document237(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ВозвратТоваровПоставщику();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ВозвратТоваровПоставщику();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(4))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(5))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка.Получить((byte[])Читалка.GetValue(8));
							Ссылка.Комментарий = Читалка.GetString(9);
							Ссылка.УчитыватьНДС = ((byte[])Читалка.GetValue(18))[0]==1;
							Ссылка.СуммаВключаетНДС = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.КурсВзаиморасчетов = Читалка.GetDecimal(20);
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.КратностьВзаиморасчетов = Читалка.GetDecimal(22);
							Ссылка.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(24));
							Ссылка.НДСВключенВСтоимость = ((byte[])Читалка.GetValue(29))[0]==1;
							Ссылка.ПоставщикуВыставляетсяСчетФактураНаВозврат = ((byte[])Читалка.GetValue(41))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ВозвратТоваровПоставщику СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ВозвратТоваровПоставщику();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийВозвратТоваровПоставщику.ПустаяСсылка;
			Объект.ВидПередачи = V82.Перечисления/*Ссылка*/.ВидыПередачиТоваров.ПустаяСсылка;
			return Объект;
		}
	}
}