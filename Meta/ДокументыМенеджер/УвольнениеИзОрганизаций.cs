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
	///(Регл)
	///</summary>
	public partial class УвольнениеИзОрганизаций:ДокументМенеджер
	{
		
		public static ДокументыСсылка.УвольнениеИзОрганизаций НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
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
		
		public static ДокументыСсылка.УвольнениеИзОрганизаций НайтиПоНомеру(string Номер)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
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
		
		public static ДокументыВыборка.УвольнениеИзОрганизаций Выбрать()
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.УвольнениеИзОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.УвольнениеИзОрганизаций ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.УвольнениеИзОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.УвольнениеИзОрганизаций ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.УвольнениеИзОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.УвольнениеИзОрганизаций СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.УвольнениеИзОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.УвольнениеИзОрганизаций СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld12078RRef [Организация]
					,_Fld12079 [Комментарий]
					,_Fld12080RRef [Ответственный]
					,_Fld12081 [КраткийСоставДокумента]
					,_Fld27368 [ДанныеПрошлойВерсии]
					,_Fld27369RRef [ИсправляемыйДокумент]
					,_Fld27370 [ДвиженияИсправляемогоДокумента]
					From _Document470(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.УвольнениеИзОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.УвольнениеИзОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(6);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ИсправляемыйДокумент = V82.ДокументыСсылка.УвольнениеИзОрганизаций.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.УвольнениеИзОрганизаций СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.УвольнениеИзОрганизаций();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.КраткийСоставДокумента = "";
			Объект.ИсправляемыйДокумент = new V82.ДокументыСсылка.УвольнениеИзОрганизаций();
			return Объект;
		}
	}
}