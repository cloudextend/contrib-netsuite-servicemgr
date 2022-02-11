
import re
import sys
import logging;
import os

logger = logging.getLogger(__name__)
logging.basicConfig(level=logging.DEBUG)

def loadFileAndValidateIfOrderAttributeExists(filename):
    logging.info(filename)
    with open(filename) as file:
        countOfOccurences=0
        for index,line in enumerate(file):
            occurencesOnLeft = validateLeftOrderAttribute(line,index)
            occurencesOnRight = validateRightOrderAttribute(line,index)
            if ( occurencesOnLeft or occurencesOnRight):
                countOfOccurences+=1
        logger.debug("Validation failures: {countOfOccurences}".format(countOfOccurences=countOfOccurences))

def validateLeftOrderAttribute(line,index):
    results = re.search("\,\sOrder=[0-9]+",line)
    if results:
        logger.warn("Found occurence of Order= in line: {index}".format(index=index))
        return True
    return False

def validateRightOrderAttribute(line,index):
    results = re.search("\(Order=[0-9]+\)", line)
    if results:
        logger.error("Found occurence of Order= in line: {index}".format(index=index))
        return True
    return False

def loadFileAndReplaceOrder(filename):
    content = ""
    with open(filename) as file:
        for line in file:
            content+=matchReplace(line)
    with open(outputFilename(filename),"w") as file:
        file.write(content)

def outputFilename(filename):
    dirname = os.path.dirname(filename)
    filename = os.path.basename(filename)
    logger.info(dirname)
    return "{dirname}/replaced-{filename}".format(dirname=dirname,filename=filename)

def matchReplace(line):
    line = matchLeftOrder(line)
    line = matchRightOrder(line)
    return line

def matchRightOrder(line):
    return re.sub("\,\sOrder=[0-9]+","",line)

def matchLeftOrder(line):
    return re.sub("\(Order=[0-9]+\)","",line)

def cliArguments():
    command = sys.argv[1]
    commandValue = sys.argv[2]
    return [command,commandValue]

if __name__=="__main__":
    [command,filename] = cliArguments()
    allowedCommands = ["--replace","--validate"]

    if command not in allowedCommands:
        logger.error("Unable to resolve command")
        exit(-1)

    logger.info("Loading file: {filename}".format(filename=filename))
    if command == "--validate":
        logger.info("Validating file.")
        loadFileAndValidateIfOrderAttributeExists(filename)
        logger.info("Finished validating file")
    if command == "--replace":
        logger.info("Replacing all occurences of Order=")
        logger.info("Started")
        loadFileAndReplaceOrder(filename)
        logger.info("Finished replacing all occurences of Order=")

