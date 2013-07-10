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
	public partial class КорректировкаДолга:ДокументМенеджер
	{
		
		public static ДокументыСсылка.КорректировкаДолга НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
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
		
		public static ДокументыСсылка.КорректировкаДолга НайтиПоНомеру(string Номер)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
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
		
		public static ДокументыВыборка.КорректировкаДолга Выбрать()
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.КорректировкаДолга();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.КорректировкаДолга ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.КорректировкаДолга();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.КорректировкаДолга ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.КорректировкаДолга();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.КорректировкаДолга СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.КорректировкаДолга();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.КорректировкаДолга СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld5599RRef [Организация]
					,_Fld5610RRef [ВидОперации]
					,_Fld5601RRef [Подразделение]
					,_Fld5600RRef [КонтрагентДебитор]
					,_Fld5614RRef [КонтрагентКредитор]
					,_Fld5604 [ОтражатьВУправленческомУчете]
					,_Fld5605 [ОтражатьВБухгалтерскомУчете]
					,_Fld5603 [Комментарий]
					,_Fld5602RRef [Ответственный]
					,_Fld5616 [ОтражатьВНалоговомУчете]
					,_Fld5611RRef [ВалютаДокумента]
					,_Fld5612 [КурсДокумента]
					,_Fld5613 [КратностьДокумента]
					,_Fld5615RRef [ДоговорКонтрагента]
					,_Fld5617 [ИспользоватьВспомогательныйСчет]
					,_Fld5606RRef [СчетДт]
					,_Fld5607RRef [СубконтоДт1]
					,_Fld5608RRef [СубконтоДт2]
					,_Fld5609RRef [СубконтоДт3]
					,_Fld5618RRef [СчетКт]
					,_Fld5619RRef [СубконтоКт1]
					,_Fld5620RRef [СубконтоКт2]
					,_Fld5621RRef [СубконтоКт3]
					,_Fld5622RRef [СчетДтНУ]
					,_Fld5623RRef [СубконтоДтНУ1]
					,_Fld5624RRef [СубконтоДтНУ2]
					,_Fld5625RRef [СубконтоДтНУ3]
					,_Fld5626RRef [СчетКтНУ]
					,_Fld5627RRef [СубконтоКтНУ1]
					,_Fld5628RRef [СубконтоКтНУ2]
					,_Fld5629RRef [СубконтоКтНУ3]
					From _Document303(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.КорректировкаДолга();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.КорректировкаДолга();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка.Получить((byte[])Читалка.GetValue(4));
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(10);
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.КурсДокумента = Читалка.GetDecimal(14);
							Ссылка.КратностьДокумента = Читалка.GetDecimal(15);
							Ссылка.ИспользоватьВспомогательныйСчет = ((byte[])Читалка.GetValue(17))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.КорректировкаДолга СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.КорректировкаДолга();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийКорректировкаДолга.ПустаяСсылка;
			return Объект;
		}
	}
}