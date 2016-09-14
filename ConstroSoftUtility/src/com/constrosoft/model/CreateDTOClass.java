package com.constrosoft.model;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class CreateDTOClass {
	public static void main(String[] args) {

		try {
			String hbmFilePath = "C:\\inetpub\\wwwroot\\ConstroSoft_v2.0\\App_Code\\Model";
			File f = new File(hbmFilePath);
			CreateDTOClass modifyHBMFile = new CreateDTOClass();
			if (f.isDirectory()) {
				Map<String, String> classNames = modifyHBMFile.getClassNames(f);
				for (File file : f.listFiles()) {
					if (!file.isDirectory() && file.getName().endsWith(".cs")) {
						modifyHBMFile.createDTO(file, classNames);
					}
				}
			} else {
				System.out.println("Directory Does not exist.");
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void createDTO(File domainFile, Map<String, String> classNames) throws IOException {
		StringBuffer dtoBuffer = new StringBuffer();
		String classLineIdentifier = "public partial class ";
		String fieldIdentifier = "public virtual ";
		BufferedReader br = null;

		try {
			br = new BufferedReader(new FileReader(domainFile));
			String line;
			String className = "";
			String dtoName = "";
			while ((line = br.readLine()) != null) {
				if (line.contains(classLineIdentifier)) {
					line = line.replace(classLineIdentifier, "");
					className = line.replace("{", "").trim();
					dtoName = classNames.get(className);
					dtoBuffer.append("    [Serializable]");
					dtoBuffer.append("\n");
					dtoBuffer.append("    public class " + dtoName + " {");
					dtoBuffer.append("\n");
					dtoBuffer.append("        public " + dtoName + " (){}");
					dtoBuffer.append("\n");
				} else if (line.contains(fieldIdentifier)) {
					String fieldName = getFieldName(line, fieldIdentifier, classNames);
					String newFieldLine = "        public " + fieldName + " { get; set; }";
					dtoBuffer.append(newFieldLine);
					dtoBuffer.append("\n");
				}
			}
			dtoBuffer.append("    }");
			System.out.println(dtoBuffer.toString());
		} catch (Exception e) {
			return;
		} finally {
			try {
				if (br != null)
					br.close();
			} catch (IOException e) {
				//
			}
		}
	}

	public Map<String, String> getClassNames(File f) throws IOException {
		Map<String, String> classNames = new HashMap<>();
		for (File file : f.listFiles()) {
			String fileName = file.getName();
			if (!file.isDirectory() && fileName.endsWith(".cs")) {
				String className = fileName.replace(".cs", "");
				classNames.put(className, className + "DTO");
			}
		}
		return classNames;
	}

	private String getFieldName(String fieldLine, String replace, Map<String, String> classNames) {
		String field = fieldLine.replace(replace, "");
		/*if (field.contains("System.Nullable")) {
			field = field.replace("System.Nullable<", "");
			field = field.replace(">", "");
		}*/
		field = field.trim();
		String type = (field.split(" ")[0]).trim();
		if(type.contains("ISet<")) {
			type = type.replace("ISet<", "");
			type = type.replace(">", "");
		}
		if(classNames.containsKey(type)) {
			field = field.replaceFirst(type, classNames.get(type));
		}
		return field.trim();
	}
}