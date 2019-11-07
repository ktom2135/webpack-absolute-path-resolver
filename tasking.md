1. Setup a config file, include: rootPath, suffix, prefix, alias:folder mapping
2. read the config file
3. read all files on the folder which match the suffix
4. generate record about alias + full path by config
5. read the file content, replace the content by logic:
   1. content begin with prefix, 
   2. content ending with file name without suffix
   3. replace content between '' with alias + full path
6. Write replace content back to file
7. process other files
