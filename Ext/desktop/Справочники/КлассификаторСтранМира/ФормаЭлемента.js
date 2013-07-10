﻿Ext.define('Справочники.КлассификаторСтранМира.ФормаЭлемента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:512px;height:108px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Классификатор стран мира',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Код',
			width: 40,
			height: 19,
			style: 'position:absolute;left:344px;top:33px;width:40px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Наименование',
			width: 162,
			height: 19,
			style: 'position:absolute;left:138px;top:33px;width:162px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'НаименованиеПолное',
			width: 366,
			height: 19,
			style: 'position:absolute;left:138px;top:56px;width:366px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьКод',
			text: 'Код:',
			style: 'position:absolute;left:302px;top:33px;width:40px;height:19px;text-align:center;',
		},
		{
			xtype: 'label',
			name: 'НадписьНаименование',
			text: 'Краткое наименование:',
			style: 'position:absolute;left:8px;top:33px;width:128px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'НадписьНаименованиеПолное',
			text: 'Полное наименование:',
			style: 'position:absolute;left:8px;top:56px;width:128px;height:19px;text-align:left;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:512px;height:25px;',
			items:
			[
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:83px;width:512px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'ОК',
				},
				'-',
				{
					text:'Записать',
				},
				'-',
				{
					text:'Закрыть',
				},
			]
		},
		{
			xtype: 'label',
			name: 'Надпись1',
			text: 'Код Альфа-2:',
			style: 'position:absolute;left:393px;top:33px;width:72px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'КодАльфа2',
			width: 40,
			height: 19,
			style: 'position:absolute;left:464px;top:33px;width:40px;height:19px;',
		},
		],
	}],
	dockedItems:
	[
	]
});