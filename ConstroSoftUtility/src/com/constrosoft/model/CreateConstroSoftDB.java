package com.constrosoft.model;

import java.io.File;
import java.io.FileInputStream;
import java.util.Iterator;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class CreateConstroSoftDB {
	static String TAB = "	";
	public static void main(String[] args) {
		try {
			File sourceFile = new File("C:\\MyData\\Sunil\\WizEye\\ConstroSoft\\DB\\ControSoft Database_21Sep2016.xlsx");
			FileInputStream file = new FileInputStream(sourceFile);

			// Create Workbook instance holding reference to .xlsx file
			XSSFWorkbook workbook = new XSSFWorkbook(file);
			// Get first/desired sheet from the workbook
			XSSFSheet sheet = workbook.getSheetAt(0);
			// Iterate through each rows one by one
			Iterator<Row> rowIterator = sheet.iterator();
			rowIterator.next();
			TableDefinition tableDefinition = null;
			StringBuffer dbScript = new StringBuffer();
			dbScript.append("--Script Generated for ->"+sourceFile.getName());
			while (rowIterator.hasNext()) {
				Row row = rowIterator.next();
				if (isTable(row)) {
					convertToScript(dbScript, tableDefinition);
					tableDefinition = new TableDefinition();
					tableDefinition.setName(row.getCell(1).getStringCellValue());
				} else {
					tableDefinition.getColumns().add(convertToColDefinition(tableDefinition.getName(), row));
				}
			}
			convertToScript(dbScript, tableDefinition);
			System.out.println(dbScript.toString());
			file.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void convertToScript(StringBuffer dbScript, TableDefinition tableDefinition) {
		if (tableDefinition != null) {
			dbScript.append("\n");
			dbScript.append("CREATE TABLE " + tableDefinition.getName() + " (");
			Iterator<ColumnDefinition> it = tableDefinition.getColumns().iterator();
			StringBuffer constraintScript = new StringBuffer();
			StringBuffer pkConstraintScript = new StringBuffer();
			while (it.hasNext()) {
				dbScript.append("\n");
				ColumnDefinition column = it.next();
				if (column.isPK()) {
					dbScript.append(TAB + column.getName() + " " + column.getDataType() + " IDENTITY(1,1) NOT NULL,");
					pkConstraintScript.append("	CONSTRAINT PK_" + tableDefinition.getName() + " PRIMARY KEY (" + column.getName() + "),");
				} else if (column.isFK()) {
					dbScript.append(TAB + column.getName() + " " + column.getDataType() + (column.isNullable() ? "," : " NOT NULL,"));
					constraintScript.append("\n");
					constraintScript.append(TAB+"CONSTRAINT " + column.getConstraintName() + " FOREIGN KEY(" + column.getName() + ") REFERENCES "
							+ column.getConstraintTable() + "(" + column.getConstraintId() + "),");
				} else if (column.isUnique()) {
					dbScript.append(TAB + column.getName() + " " + column.getDataType() + " NOT NULL UNIQUE,");
				} else {
					dbScript.append(TAB + column.getName() + " " + column.getDataType() + (column.isNullable() ? "" : " NOT NULL")
							+ (!"".equalsIgnoreCase(column.getDefaultVal()) ? " DEFAULT " + column.getDefaultVal() + "," : ","));
				}
			}
			dbScript.append("\n");
			dbScript.append(pkConstraintScript.toString());
			dbScript.append(constraintScript.toString());
			dbScript.replace(dbScript.length() - 1, dbScript.length(), "");
			dbScript.append("\n );");
			dbScript.append("\n");
			dbScript.append("GO");
		}
	}

	private static ColumnDefinition convertToColDefinition(String tableName, Row row) throws Exception {
		ColumnDefinition column = new ColumnDefinition();
		String colName = getStringValue(row.getCell(1));
		String dataType = getStringValue(row.getCell(2));
		String length = getStringValue(row.getCell(3));
		String nullable = getStringValue(row.getCell(4));
		String defaultVal = getStringValue(row.getCell(5));
		String constraint = getStringValue(row.getCell(6));
		String constraintName = getStringValue(row.getCell(7));
		String constraintTable = getStringValue(row.getCell(8));
		String constraintColumn = getStringValue(row.getCell(9));
		if (colName == null || "".equalsIgnoreCase(colName.trim()))
			throw new Exception("Column Name can not be empty:" + tableName);
		if (dataType == null || "".equalsIgnoreCase(dataType.trim()))
			throw new Exception("Data Type can not be empty:" + tableName);
		column.setName(colName);
		column.setDataType(getDataType(tableName, dataType, length));
		column.setNullable(!"No".equalsIgnoreCase(nullable));
		column.setDefaultVal(getDefaultValue(dataType, defaultVal));
		column.setPK("PK".equalsIgnoreCase(constraint));
		column.setFK("FK".equalsIgnoreCase(constraint));
		column.setUnique("UNIQUE".equalsIgnoreCase(constraint));
		if (column.isFK() && (constraintColumn == null || "".equalsIgnoreCase(constraintColumn.trim())))
			throw new Exception("Constraint column id can not be empty:" + tableName);
		column.setConstraintName(constraintName);
		column.setConstraintTable(constraintTable);
		column.setConstraintId(constraintColumn);
		return column;
	}

	private static String getStringValue(Cell cell) {
		String result = "";
		switch (cell.getCellType()) {
		case Cell.CELL_TYPE_NUMERIC:
			result = cell.getNumericCellValue() + "";
			result = result.substring(0, result.indexOf("."));
			break;
		default:
			result = cell.getStringCellValue();
		}
		return result;
	}

	private static String getDataType(String tableName, String tmpDataType, String length) throws Exception {
		String result = tmpDataType;
		if ("nvarchar".equalsIgnoreCase(tmpDataType)) {
			if (length == null || "".equalsIgnoreCase(length.trim()))
				throw new Exception("Data Type length can not be empty:" + tableName);
			result = tmpDataType + "(" + length + ")";
		} else if ("numeric".equalsIgnoreCase(tmpDataType)) {
			if (length == null || "".equalsIgnoreCase(length.trim()))
				throw new Exception("Data Type length can not be empty:" + tableName);
			result = tmpDataType + "(" + length + ")";
		}

		return result.toUpperCase();
	}

	private static String getDefaultValue(String dataType, String defaultVal) {
		String result = (defaultVal != null) ? defaultVal : "";
		if ("nvarchar".equalsIgnoreCase(dataType) && !"".equalsIgnoreCase(defaultVal)) {
			result = "'" + defaultVal + "'";
		}
		return result.toUpperCase();
	}

	private static boolean isTable(Row row) {
		String value = row.getCell(0).getStringCellValue();
		return value != null && "TABLE".equalsIgnoreCase(value);
	}
}
