﻿Ext.define('Документы.Встречи.РасшифровкаЗанятости',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:641px;height:130px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: '<ФИО|Помещение>',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'Наименование',
			text: '',
			style: 'position:absolute;left:8px;top:25px;width:625px;height:22px;',
		},
		{
			xtype: 'label',
			name: 'ОписаниеЗанятости',
			text: '',
			style: 'position:absolute;left:8px;top:52px;width:625px;height:15px;',
		},
		{
			xtype: 'label',
			name: 'НадписьДокумент',
			text: 'Документ',
			style: 'position:absolute;left:8px;top:87px;width:194px;height:15px;',
		},
		{
			xtype: 'label',
			name: 'Документ',
			text: '',
			style: 'position:absolute;left:207px;top:87px;width:426px;height:15px;',
		},
		{
			xtype: 'label',
			name: 'НадписьТелефоны',
			text: 'Телефоны',
			style: 'position:absolute;left:8px;top:107px;width:194px;height:15px;',
		},
		{
			xtype: 'label',
			name: 'Телефоны',
			text: '',
			style: 'position:absolute;left:207px;top:107px;width:426px;height:15px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:641px;height:25px;',
			dock: 'top',
			items:
			[
				{
					text:'Открыть документ занятости',
				},
			]
		},
	]
});