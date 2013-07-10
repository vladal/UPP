﻿Ext.define('Справочники.ВложенияЭлектронныхПисем.ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:608px;height:321px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Вложения электронных писем',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:592px;height:280px;',
			height: 280,width: 592,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Наименование',
					width:'220',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Электронное письмо',
					width:'120',
					dataIndex:'Объект',
					flex:1,
				},
				{
					text:'Имя файла',
					width:'220',
					dataIndex:'ИмяФайла',
					flex:1,
				},
				{
					text:'ИДФайла почтового письма',
					width:'120',
					dataIndex:'ИДФайлаПочтовогоПисьма',
					flex:1,
				},
				{
					text:'Предмет',
					width:'120',
					dataIndex:'Предмет',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.ВложенияЭлектронныхПисем").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ВложенияЭлектронныхПисем/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'Наименование',
					},
					{
						name:'Объект',
					},
					{
						name:'ИмяФайла',
					},
					{
						name:'ИДФайлаПочтовогоПисьма',
					},
					{
						name:'Предмет',
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
						var грид = Ext.getCmp('СправочникСписок');
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
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:608px;height:25px;',
			dock: 'top',
			items:
			[
			]
		},
	]
});