﻿Ext.define('Документы.Опрос.ФормаВводаОтветовТеста',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:366px;height:561px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Опрос',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:261px;width:350px;height:249px;',
			height: 249,width: 350,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Строка',
					items:
					[
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'Строка',
			width: 350,
			height: 19,
			style: 'position:absolute;left:0px;top:6px;width:350px;height:19px;',
		},
					]
				},
				{
					title:'Булево',
					items:
					[
		{
			xtype: 'combobox',
			style: 'position:absolute;left:0px;top:0px;width:350px;height:19px;',
		},
					]
				},
				{
					title:'Один из вариантов ответа',
					items:
					[
		{
			xtype: 'combobox',
			style: 'position:absolute;left:8px;top:24px;width:342px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьРазвернутыйОтвет',
			text: 'Развернутый ответ:',
			style: 'position:absolute;left:8px;top:48px;width:342px;height:19px;',
		},
		{
			xtype: 'radiogroup',
			defaults: {name: 'ccType'},
			items: [
		{
			xtype: 'radio',
			boxLabel: 'Переключатель',
			style: 'position:absolute;left:8px;top:0px;width:342px;height:19px;',
		},
			]
		},
					]
				},
				{
					title:'Несколько вариантов ответа',
					items:
					[
		{
			id: 'НесколькоВариантовОтветов',
			xtype: 'grid',
			style: 'position:absolute;left:0px;top:0px;width:350px;height:238px;',
			height: 238,width: 350,
			columns:
			[
				{
					text:'',
					width:'25',
					dataIndex:'Выбор',
					flex:1,
				},
				{
					text:'№',
					width:'35',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Составной ответ',
					width:'204',
					dataIndex:'ВариантОтвета',
					flex:1,
				},
				{
					text:'Развернутый ответ',
					width:'200',
					dataIndex:'Ответ',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/Опрос/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Выбор',
					},
					{
						name:'НомерСтроки',
					},
					{
						name:'ВариантОтвета',
					},
					{
						name:'Ответ',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('НесколькоВариантовОтветов');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
					]
				},
				{
					title:'Адрес',
					items:
					[
		{
			xtype: 'label',
			name: 'Надпись6',
			text: 'Регион:',
			style: 'position:absolute;left:0px;top:0px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Регион',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:0px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись7',
			text: 'Район:',
			style: 'position:absolute;left:0px;top:24px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Район',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:24px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись8',
			text: 'Город:',
			style: 'position:absolute;left:0px;top:48px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Город',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:48px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись9',
			text: 'Нас. пункт:',
			style: 'position:absolute;left:0px;top:72px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'НаселенныйПункт',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:72px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись10',
			text: 'Улица:',
			style: 'position:absolute;left:0px;top:96px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Улица',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:96px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись11',
			text: 'Дом:',
			style: 'position:absolute;left:0px;top:120px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Дом',
			width: 35,
			height: 19,
			style: 'position:absolute;left:94px;top:120px;width:35px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись12',
			text: 'Корпус:',
			style: 'position:absolute;left:140px;top:120px;width:52px;height:19px;text-align:center;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Корпус',
			width: 35,
			height: 19,
			style: 'position:absolute;left:192px;top:120px;width:35px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись13',
			text: 'Квартира:',
			style: 'position:absolute;left:249px;top:120px;width:60px;height:19px;text-align:center;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Квартира',
			width: 35,
			height: 19,
			style: 'position:absolute;left:309px;top:120px;width:35px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'КомментарийАдрес',
			width: 250,
			height: 19,
			style: 'position:absolute;left:94px;top:168px;width:250px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись15',
			text: 'Комментарий:',
			style: 'position:absolute;left:0px;top:168px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'Надпись14',
			text: 'Индекс:',
			style: 'position:absolute;left:0px;top:144px;width:94px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Индекс',
			width: 60,
			height: 19,
			style: 'position:absolute;left:94px;top:144px;width:60px;height:19px;',
		},
					]
				},
				{
					title:'Телефон',
					items:
					[
		{
			xtype: 'label',
			name: 'Надпись16',
			text: 'Код страны:',
			style: 'position:absolute;left:0px;top:24px;width:79px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Поле1',
			width: 140,
			height: 19,
			style: 'position:absolute;left:79px;top:24px;width:140px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись17',
			text: 'Код города:',
			style: 'position:absolute;left:0px;top:48px;width:79px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Поле2',
			width: 140,
			height: 19,
			style: 'position:absolute;left:79px;top:48px;width:140px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись18',
			text: 'Номер :',
			style: 'position:absolute;left:0px;top:0px;width:79px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Поле3',
			width: 124,
			height: 19,
			style: 'position:absolute;left:79px;top:0px;width:124px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись19',
			text: 'Добавочный:',
			style: 'position:absolute;left:209px;top:0px;width:75px;height:19px;text-align:center;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Поле4',
			width: 60,
			height: 19,
			style: 'position:absolute;left:287px;top:0px;width:60px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'КомментарийТелефон',
			width: 268,
			height: 19,
			style: 'position:absolute;left:79px;top:72px;width:268px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись20',
			text: 'Комментарий:',
			style: 'position:absolute;left:0px;top:72px;width:79px;height:19px;text-align:left;',
		},
					]
				},
				{
					title:'Адрес электронной почты',
				},
				{
					title:'Веб страница',
				},
				{
					title:'Другое',
				},
				{
					title:'Табличный',
					items:
					[
		{
			id: 'ТабличноеПолеСоставногоОтвета',
			xtype: 'grid',
			style: 'position:absolute;left:0px;top:0px;width:350px;height:238px;',
			height: 238,width: 350,
			columns:
			[
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/Опрос/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ТабличноеПолеСоставногоОтвета');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
					]
				},
				{
					title:'Текст',
					items:
					[
		{
			xtype: 'textarea',
			hideLabel: true,
			disabled: false,
			name: 'ПолеВводаТекст',
			style: 'position:absolute;left:0px;top:0px;width:350px;height:238px;',
		},
					]
				},
			]
		},
		{
			xtype: 'label',
			name: 'Вопрос',
			text: '',
			style: 'position:absolute;left:8px;top:195px;width:350px;height:38px;text-align:left;',
		},
		{
			xtype: 'fieldset',
			title: 'Вопрос:',
			style: 'position:absolute;left:8px;top:10px;width:350px;height:16px;',
		},
		{
			xtype: 'fieldset',
			title: 'Ответ:',
			style: 'position:absolute;left:8px;top:240px;width:350px;height:16px;',
		},
		{
			xtype: 'label',
			name: 'НадписьПредставлениеПрошлоСекунд',
			text: '00:00',
			style: 'position:absolute;left:66px;top:515px;width:33px;height:15px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:536px;width:366px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'Назад',
				},
				{
					text:'Далее',
				},
				{
					text:'ОК',
				},
			]
		},
		{
			xtype: 'label',
			name: 'Прошло',
			text: 'Прошло:',
			style: 'position:absolute;left:8px;top:515px;width:50px;height:15px;',
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:29px;width:350px;height:162px;',
			height: 162,width: 350,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Страница1',
					items:
					[
					]
				},
			]
		},
		{
			xtype: 'label',
			name: 'НадписьПредставлениеОсталосьСекунд',
			text: '00:00',
			style: 'position:absolute;left:184px;top:515px;width:33px;height:15px;',
		},
		{
			xtype: 'label',
			name: 'Осталось',
			text: 'Осталось:',
			style: 'position:absolute;left:115px;top:515px;width:59px;height:15px;',
		},
		],
	}],
	dockedItems:
	[
	]
});